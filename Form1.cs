using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using InteriorDesigner.Models;
using InteriorDesigner.Servisec;
using InteriorDesigner.Graphics;

namespace InteriorDesigner
{
    public partial class Form1 : Form
    {
        private Camera camera = new();
        private Mesh cubeMesh;
        private ProjectData project = new ProjectData();

        private bool isRotating = false;
        private Point lastMousePosition;
        private float yaw = -90f;
        private float pitch = -20f;
        private bool moveMode = false;

        private Dictionary<string, ObjModel> loadedModels = new();
        private Dictionary<string, ObjMesh> loadedMeshes = new();

        private bool rotateMode = false;
        private bool showCeiling = false;

        private Furniture? selectedFurniture;

        public Form1()
        {
            InitializeComponent();
            glControl1.Load += GlControl1_Load;
            glControl1.Paint += GlControl1_Paint;
            glControl1.Resize += GlControl1_Resize;
            this.KeyPreview = true;

            glControl1.MouseDown += GlControl1_MouseDown;
            glControl1.MouseUp += GlControl1_MouseUp;
            glControl1.MouseMove += GlControl1_MouseMove;
            glControl1.MouseWheel += GlControl1_MouseWheel;
            glControl1.MouseClick += GlControl1_MouseClick;

            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;

            miFloorColor.Click += miFloorColor_Click;
            miCeilingColor.Click += miCeilingColor_Click;

            miLeftWallColor.Click += miLeftWallColor_Click;
            miRightWallColor.Click += miRightWallColor_Click;

            miFrontWallColor.Click += miFrontWallColor_Click;
            miBackWallColor.Click += miBackWallColor_Click;

            miObjectColor.Click += miObjectColor_Click;
        }

        private void GlControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Multisample);
            GL.Enable(EnableCap.LineSmooth);

            string vertexShader = @"#version 330 core
                layout (location = 0) in vec3 aPosition;
                uniform mat4 model;
                uniform mat4 view;
                uniform mat4 projection;
                out vec3 FragPos;
                
                void main()
                {
                    vec4 worldPos = model * vec4(aPosition, 1.0);
                    FragPos = worldPos.xyz;
                    gl_Position = projection * view * worldPos;
                }";
            string fragmentShader = @"#version 330 core
                uniform vec3 objectColor;
                in vec3 FragPos;
                out vec4 FragColor;
                
                void main()
                {
                    vec3 lightPos = vec3(5.0, 10.0, 0.0);
                    float distanceToLight = length(lightPos - FragPos);
                    float brightness = 3.0 / (1.0 + distanceToLight * 0.15);
                    vec3 finalColor = objectColor * brightness;
                    FragColor = vec4(finalColor, 1.0);
                }";
            shader = new Shader(vertexShader, fragmentShader);
            cubeMesh = new Mesh(CubeMesh.Vertices);
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            shader.Use();

            Matrix4 view = camera.GetViewMatrix();
            Matrix4 projection = camera.GetProjectionMatrix(glControl1.Width / (float)glControl1.Height);

            int viewLoc = GL.GetUniformLocation(shader.Handle, "view");

            GL.UniformMatrix4(viewLoc, false, ref view);

            int projLoc = GL.GetUniformLocation(shader.Handle, "projection");

            GL.UniformMatrix4(projLoc, false, ref projection);

            if (project.Room != null)
            {
                DrawRoom3D();
            }

            DrawFurniture();
            glControl1.SwapBuffers();
        }

        private void GlControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            glControl1.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            float speed = 0.5f;

            if (e.KeyCode == Keys.W)
                camera.Position += camera.Front * speed;

            if (e.KeyCode == Keys.S)
                camera.Position -= camera.Front * speed;

            if (e.KeyCode == Keys.A)
                camera.Position -= Vector3.Normalize(Vector3.Cross(camera.Front, camera.Up)) * speed;

            if (e.KeyCode == Keys.D)
                camera.Position += Vector3.Normalize(Vector3.Cross(camera.Front, camera.Up)) * speed;

            if (moveMode && selectedFurniture != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.J:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.X -= 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }

                    case Keys.L:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.X += 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }

                    case Keys.I:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.Z -= 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }

                    case Keys.K:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.Z += 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }
                    case Keys.U:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.Y += 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }

                    case Keys.O:
                        {
                            Vector3 pos = selectedFurniture.Position;
                            pos.Y -= 0.2f;
                            selectedFurniture.Position = pos;
                            break;
                        }
                }
            }

            if (rotateMode && selectedFurniture != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        selectedFurniture.RotationY -= 5;
                        break;

                    case Keys.X:
                        selectedFurniture.RotationY += 5;
                        break;

                    case Keys.C:
                        selectedFurniture.RotationX -= 5;
                        break;

                    case Keys.V:
                        selectedFurniture.RotationX += 5;
                        break;

                    case Keys.B:
                        selectedFurniture.RotationZ -= 5;
                        break;

                    case Keys.N:
                        selectedFurniture.RotationZ += 5;
                        break;
                }
            }

            glControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Shader shader;
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm();

            if (roomForm.ShowDialog() == DialogResult.OK)
            {
                project.Room = roomForm.Room;
                glControl1.Invalidate();

                UpdateStatus();
            }
        }

        private int furnitureCounter = 1;

        private void btnAddFurniture_Click(object sender, EventArgs e)
        {
            Furniture furniture = new Furniture();
            furniture.Id = furnitureCounter++;
            furniture.Name = $"Диван {furniture.Id}";
            furniture.Position = new Vector3(0, 0, 0);
            furniture.Scale = new Vector3(1.5f, 0.8f, 0.8f);
            furniture.Color = new Vector3(0, 0, 1);

            project.FurnitureList.Add(furniture);
            lstObjects.Items.Add(furniture.Name);
            glControl1.Invalidate();
        }
        private void DrawFurniture()
        {
            foreach (var item in project.FurnitureList)
            {
                Matrix4 model = Matrix4.CreateScale(item.Scale) * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(item.Rotation.X)) * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(item.Rotation.Y)) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(item.Rotation.Z)) * Matrix4.CreateTranslation(item.Position);
                int modelLoc = GL.GetUniformLocation(shader.Handle, "model");
                GL.UniformMatrix4(modelLoc, false, ref model);
                int colorLoc = GL.GetUniformLocation(shader.Handle, "objectColor");

                Vector3 drawColor = item.Color;
                if (selectedFurniture == item)
                {
                    drawColor *= 1.4f;
                    drawColor.X = MathF.Min(drawColor.X, 1f);
                    drawColor.Y = MathF.Min(drawColor.Y, 1f);
                    drawColor.Z = MathF.Min(drawColor.Z, 1f);
                }

                GL.Uniform3(colorLoc, drawColor);

                if (string.IsNullOrEmpty(item.ModelPath))
                {
                    cubeMesh.Draw();
                }
                else
                {
                    if (loadedMeshes.ContainsKey(item.ModelPath))
                    {
                        ObjMesh mesh = loadedMeshes[item.ModelPath];
                        // Основная модель
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                        mesh.Draw();
                        // Каркас
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                        GL.LineWidth(1f);
                        GL.Uniform3(colorLoc, new Vector3(0.0f, 0.0f, 0.0f));
                        mesh.Draw();
                        GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                        GL.Uniform3(colorLoc, drawColor);
                    }
                    else
                    {
                        cubeMesh.Draw();
                    }
                }
            }
        }

        private void lstObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstObjects.SelectedIndex < 0)
                return;

            propertyGrid1.SelectedObject = project.FurnitureList[lstObjects.SelectedIndex];
            selectedFurniture = project.FurnitureList[lstObjects.SelectedIndex];

            glControl1.Focus();
            glControl1.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (propertyGrid1.SelectedObject is Furniture furniture)
            {
                furniture.ApplyMaterial();
                propertyGrid1.Refresh();
            }

            glControl1.Invalidate();
        }

        private void btnImportModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "3D Models|*.obj";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            Furniture furniture = new Furniture();
            furniture.Id = furnitureCounter++;
            furniture.Name = Path.GetFileNameWithoutExtension(dialog.FileName);
            furniture.ModelPath = dialog.FileName;

            if (!loadedModels.ContainsKey(dialog.FileName))
            {
                loadedModels.Add(dialog.FileName, ObjLoader.Load(dialog.FileName));
                ObjModel model = loadedModels[dialog.FileName];

                float scale = model.RecommendedScale;

                furniture.ScaleX = scale;
                furniture.ScaleY = scale;
                furniture.ScaleZ = scale;

                loadedMeshes.Add(dialog.FileName, new ObjMesh(model));
            }


            furniture.Color = new Vector3(0.8f, 0.8f, 0.8f);
            project.FurnitureList.Add(furniture);
            lstObjects.Items.Add(furniture.Name);
            glControl1.Invalidate();
        }

        private void DrawRoom3D()
        {
            float width = project.Room.Width;
            float height = project.Room.Height;
            float length = project.Room.Length;

            Vector3 floorColor = new Vector3(project.Room.FloorR, project.Room.FloorG, project.Room.FloorB);

            Vector3 ceilingColor = new Vector3(project.Room.CeilingR, project.Room.CeilingG, project.Room.CeilingB);

            Vector3 wallColor1 = new Vector3(project.Room.LeftWallR, project.Room.LeftWallG, project.Room.LeftWallB);

            Vector3 wallColor2 = new Vector3(project.Room.RightWallR, project.Room.RightWallG, project.Room.RightWallB);

            Vector3 wallColor3 = new Vector3(project.Room.BackWallR, project.Room.BackWallG, project.Room.BackWallB);

            Vector3 wallColor4 = new Vector3(project.Room.FrontWallR, project.Room.FrontWallG, project.Room.FrontWallB);

            // Пол
            Matrix4 floor = Matrix4.CreateScale(width, 0.1f, length) * Matrix4.CreateTranslation(0, -0.05f, 0);

            DrawCube(floor, floorColor);

            ////// Потолок
            if (showCeiling)
            {
                Matrix4 ceiling = Matrix4.CreateScale(width, 0.1f, length) * Matrix4.CreateTranslation(0, height, 0);

                DrawCube(ceiling, ceilingColor);
            }

            // Левая стена
            Matrix4 wallLeft = Matrix4.CreateScale(0.1f, height, length) * Matrix4.CreateTranslation(-width / 2f, height / 2f, 0);

            DrawCube(wallLeft, wallColor1);

            // Правая стена
            Matrix4 wallRight = Matrix4.CreateScale(0.1f, height, length) * Matrix4.CreateTranslation(width / 2f, height / 2f, 0);

            DrawCube(wallRight, wallColor2);

            // Задняя стена
            Matrix4 wallBack = Matrix4.CreateScale(width, height, 0.1f) * Matrix4.CreateTranslation(0, height / 2f, -length / 2f);

            DrawCube(wallBack, wallColor3);

            // Передняя стена
            Matrix4 wallFront = Matrix4.CreateScale(width, height, 0.1f) * Matrix4.CreateTranslation(0, height / 2f, length / 2f);

            DrawCube(wallFront, wallColor4);
        }

        private void DrawCube(Matrix4 model, Vector3 color)
        {
            int modelLoc = GL.GetUniformLocation(shader.Handle, "model");

            GL.UniformMatrix4(modelLoc, false, ref model);

            int colorLoc = GL.GetUniformLocation(shader.Handle, "objectColor");

            GL.Uniform3(colorLoc, color);

            cubeMesh.Draw();
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = project.Room;
        }

        private void GlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRotating = true;
                lastMousePosition = e.Location;
            }
        }

        private void GlControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRotating = false;
            }
        }

        private void GlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isRotating)
                return;

            float sensitivity = 0.3f;

            float deltaX = e.X - lastMousePosition.X;

            float deltaY = e.Y - lastMousePosition.Y;

            yaw += deltaX * sensitivity;

            pitch -= deltaY * sensitivity;

            if (pitch > 89f)
                pitch = 89f;

            if (pitch < -89f)
                pitch = -89f;

            Vector3 front;

            front.X = MathF.Cos(MathHelper.DegreesToRadians(yaw)) * MathF.Cos(MathHelper.DegreesToRadians(pitch));

            front.Y = MathF.Sin(MathHelper.DegreesToRadians(pitch));

            front.Z = MathF.Sin(MathHelper.DegreesToRadians(yaw)) * MathF.Cos(MathHelper.DegreesToRadians(pitch));

            camera.Front = Vector3.Normalize(front);

            lastMousePosition = e.Location;

            glControl1.Invalidate();
        }
        private void GlControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.Position += camera.Front * (e.Delta * 0.01f);
            glControl1.Invalidate();

            if (selectedFurniture != null && ModifierKeys == Keys.Control)
            {
                selectedFurniture.ScaleX += e.Delta * 0.001f;
                selectedFurniture.ScaleY += e.Delta * 0.001f;
                selectedFurniture.ScaleZ += e.Delta * 0.001f;

                glControl1.Invalidate();

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Интерьерный проект (*json)|*.json";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            SaveLoadService.Save(project, dialog.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Интерьерный проект (*json)|*.json";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            project = SaveLoadService.Load(dialog.FileName);

            loadedMeshes.Clear();
            loadedModels.Clear();

            lstObjects.Items.Clear();

            foreach (var item in project.FurnitureList)
            {
                if (!string.IsNullOrEmpty(item.ModelPath))
                {
                    if (File.Exists(item.ModelPath))
                    {
                        ObjModel model = ObjLoader.Load(item.ModelPath);
                        loadedModels.Add(item.ModelPath, model);
                        loadedMeshes.Add(item.ModelPath, new ObjMesh(model));
                    }
                }
            }

            foreach (var item in project.FurnitureList)
            {
                lstObjects.Items.Add(item.Name);
            }
            glControl1.Invalidate();
        }

        private void btnExportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "PNG Image (*.png)|*.png";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SaveScreenshot(dialog.FileName);
        }

        private void SaveScreenshot(string fileName)
        {
            int width = glControl1.Width;
            int height = glControl1.Height;
            Bitmap bitmap = new Bitmap(width, height);

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            GL.ReadPixels(0, 0, width, height, OpenTK.Graphics.OpenGL4.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);

            MessageBox.Show("Изображение сохранено.");
        }

        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            if (lstObjects.SelectedIndex < 0)
                return;

            int index = lstObjects.SelectedIndex;
            project.FurnitureList.RemoveAt(index);
            lstObjects.Items.RemoveAt(index);
            propertyGrid1.SelectedObject = null;

            glControl1.Invalidate();
        }
        private void GlControl1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (project.FurnitureList.Count == 0)
            //    return;
            //selectedFurniture = project.FurnitureList[0];
            //propertyGrid1.SelectedObject = selectedFurniture;

            //glControl1.Invalidate();
        }

        private void btnMoveSelected_Click(object sender, EventArgs e)
        {
            moveMode = !moveMode;

            if (moveMode)
            {
                btnMoveSelected.Text = "Режим перемещения ВКЛ";
            }
            else
            {
                btnMoveSelected.Text = "Переместить объект";
            }
        }

        private void UpdateStatus()
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void miCreateRoom_Click(object sender, EventArgs e)
        {
            btnCreateRoom_Click(sender, e);
        }

        private void miNewProject_Click(object sender, EventArgs e)
        {
            project = new ProjectData();
            lstObjects.Items.Clear();
            propertyGrid1.SelectedObject = null;
            glControl1.Invalidate();
        }

        private void miOpenProject_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void miSaveProject_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void miExportPng_Click(object sender, EventArgs e)
        {
            btnExportImage_Click(sender, e);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miAddFurniture_Click(object sender, EventArgs e)
        {
            btnAddFurniture_Click(sender, e);
        }

        private void miImportObj_Click(object sender, EventArgs e)
        {
            btnImportModel_Click(sender, e);
        }

        private void miDeleteObject_Click(object sender, EventArgs e)
        {
            btnDeleteObject_Click(sender, e);
        }

        private void miResetCamera_Click(object sender, EventArgs e)
        {
            camera.Position = new Vector3(0, 5, 10);
            camera.Front = -Vector3.UnitZ;
            glControl1.Invalidate();
        }

        private void btnRotateMode_Click(object sender, EventArgs e)
        {
            rotateMode = !rotateMode;

            if (rotateMode)
            {
                btnRotateMode.Text = "Режим Вращения ВКЛ";
            }
            else
            {
                btnRotateMode.Text = "Вращать объект";
            }
        }

        private void miCeilingDisplay_Click(object sender, EventArgs e)
        {
            showCeiling = !showCeiling;

            if (showCeiling)
            {
                miCeilingDisplay.Text = "Потолок: ВКЛ";
                miCeilingDisplay.Checked = true;
            }
            else
            {
                miCeilingDisplay.Text = "Потолок: ВЫКЛ";
                miCeilingDisplay.Checked = false;
            }
            glControl1.Invalidate();
        }

        private void ChangeColor(Action<Color> applyColor)
        {
            ColorDialog dlg = new();

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            applyColor(dlg.Color);

            glControl1.Invalidate();
        }

        private void miFloorColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.FloorR = color.R / 255f;
                project.Room.FloorG = color.G / 255f;
                project.Room.FloorB = color.B / 255f;
            });
        }

        private void miCeilingColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.CeilingR = color.R / 255f;
                project.Room.CeilingG = color.G / 255f;
                project.Room.CeilingB = color.B / 255f;
            });
        }

        private void miLeftWallColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.LeftWallR = color.R / 255f;
                project.Room.LeftWallG = color.G / 255f;
                project.Room.LeftWallB = color.B / 255f;
            });
        }

        private void miRightWallColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.RightWallR = color.R / 255f;
                project.Room.RightWallG = color.G / 255f;
                project.Room.RightWallB = color.B / 255f;
            });
        }

        private void miFrontWallColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.FrontWallR = color.R / 255f;
                project.Room.FrontWallG = color.G / 255f;
                project.Room.FrontWallB = color.B / 255f;
            });
        }

        private void miBackWallColor_Click(object sender, EventArgs e)
        {
            if (project.Room == null)
                return;

            ChangeColor(color =>
            {
                project.Room.BackWallR = color.R / 255f;
                project.Room.BackWallG = color.G / 255f;
                project.Room.BackWallB = color.B / 255f;
            });
        }

        private void miObjectColor_Click(object sender, EventArgs e)
        {
            if (selectedFurniture == null)
            {
                MessageBox.Show("Выберите объект.");
                return;
            }

            ChangeColor(color =>
            {
                selectedFurniture.ColorR = color.R / 255f;
                selectedFurniture.ColorG = color.G / 255f;
                selectedFurniture.ColorB = color.B / 255f;
            });
        }
    }
}
