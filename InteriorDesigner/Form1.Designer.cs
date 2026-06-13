namespace InteriorDesigner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelTools = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnRotateMode = new Button();
            btnMoveSelected = new Button();
            btnEditRoom = new Button();
            propertyGrid1 = new PropertyGrid();
            lstObjects = new ListBox();
            glControl1 = new OpenTK.GLControl.GLControl();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            miNewProject = new ToolStripMenuItem();
            miOpenProject = new ToolStripMenuItem();
            miSaveProject = new ToolStripMenuItem();
            miExportPng = new ToolStripMenuItem();
            miExit = new ToolStripMenuItem();
            помещениеToolStripMenuItem = new ToolStripMenuItem();
            miCreateRoom = new ToolStripMenuItem();
            объектыToolStripMenuItem = new ToolStripMenuItem();
            miAddFurniture = new ToolStripMenuItem();
            miImportObj = new ToolStripMenuItem();
            miDeleteObject = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            miResetCamera = new ToolStripMenuItem();
            miCeilingDisplay = new ToolStripMenuItem();
            настройкаЦветаToolStripMenuItem = new ToolStripMenuItem();
            miFloorColor = new ToolStripMenuItem();
            miCeilingColor = new ToolStripMenuItem();
            miLeftWallColor = new ToolStripMenuItem();
            miRightWallColor = new ToolStripMenuItem();
            miFrontWallColor = new ToolStripMenuItem();
            miBackWallColor = new ToolStripMenuItem();
            miObjectColor = new ToolStripMenuItem();
            panelTools.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTools
            // 
            panelTools.Controls.Add(label2);
            panelTools.Controls.Add(label1);
            panelTools.Controls.Add(btnRotateMode);
            panelTools.Controls.Add(btnMoveSelected);
            panelTools.Controls.Add(btnEditRoom);
            panelTools.Controls.Add(propertyGrid1);
            panelTools.Controls.Add(lstObjects);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 28);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(250, 787);
            panelTools.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(57, 379);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 14;
            label2.Text = "Редактор свойств";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(57, 126);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 13;
            label1.Text = "Список объектов";
            // 
            // btnRotateMode
            // 
            btnRotateMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRotateMode.Location = new Point(12, 73);
            btnRotateMode.Name = "btnRotateMode";
            btnRotateMode.Size = new Size(232, 29);
            btnRotateMode.TabIndex = 12;
            btnRotateMode.Text = "Вращать объект";
            btnRotateMode.UseVisualStyleBackColor = true;
            btnRotateMode.Click += btnRotateMode_Click;
            // 
            // btnMoveSelected
            // 
            btnMoveSelected.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnMoveSelected.Location = new Point(12, 38);
            btnMoveSelected.Name = "btnMoveSelected";
            btnMoveSelected.Size = new Size(232, 29);
            btnMoveSelected.TabIndex = 11;
            btnMoveSelected.Text = "Переместить объект";
            btnMoveSelected.UseVisualStyleBackColor = true;
            btnMoveSelected.Click += btnMoveSelected_Click;
            // 
            // btnEditRoom
            // 
            btnEditRoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEditRoom.Location = new Point(12, 3);
            btnEditRoom.Name = "btnEditRoom";
            btnEditRoom.Size = new Size(232, 29);
            btnEditRoom.TabIndex = 8;
            btnEditRoom.Text = "Параметры комнаты";
            btnEditRoom.UseVisualStyleBackColor = true;
            btnEditRoom.Click += btnEditRoom_Click;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            propertyGrid1.Location = new Point(0, 402);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(250, 385);
            propertyGrid1.TabIndex = 6;
            // 
            // lstObjects
            // 
            lstObjects.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstObjects.FormattingEnabled = true;
            lstObjects.Location = new Point(3, 149);
            lstObjects.Name = "lstObjects";
            lstObjects.Size = new Size(244, 204);
            lstObjects.TabIndex = 5;
            lstObjects.SelectedIndexChanged += lstObjects_SelectedIndexChanged;
            // 
            // glControl1
            // 
            glControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl1.APIVersion = new Version(3, 3, 0, 0);
            glControl1.Dock = DockStyle.Fill;
            glControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl1.IsEventDriven = true;
            glControl1.Location = new Point(250, 28);
            glControl1.Name = "glControl1";
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glControl1.SharedContext = null;
            glControl1.Size = new Size(1601, 787);
            glControl1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, помещениеToolStripMenuItem, объектыToolStripMenuItem, видToolStripMenuItem, настройкаЦветаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1851, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miNewProject, miOpenProject, miSaveProject, miExportPng, miExit });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // miNewProject
            // 
            miNewProject.Name = "miNewProject";
            miNewProject.Size = new Size(192, 26);
            miNewProject.Text = "Новый проект";
            miNewProject.Click += miNewProject_Click;
            // 
            // miOpenProject
            // 
            miOpenProject.Name = "miOpenProject";
            miOpenProject.Size = new Size(192, 26);
            miOpenProject.Text = "Открыть";
            miOpenProject.Click += miOpenProject_Click;
            // 
            // miSaveProject
            // 
            miSaveProject.Name = "miSaveProject";
            miSaveProject.Size = new Size(192, 26);
            miSaveProject.Text = "Сохранить";
            miSaveProject.Click += miSaveProject_Click;
            // 
            // miExportPng
            // 
            miExportPng.Name = "miExportPng";
            miExportPng.Size = new Size(192, 26);
            miExportPng.Text = "Экспорт PNG";
            miExportPng.Click += miExportPng_Click;
            // 
            // miExit
            // 
            miExit.Name = "miExit";
            miExit.Size = new Size(192, 26);
            miExit.Text = "Выход";
            miExit.Click += miExit_Click;
            // 
            // помещениеToolStripMenuItem
            // 
            помещениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCreateRoom });
            помещениеToolStripMenuItem.Name = "помещениеToolStripMenuItem";
            помещениеToolStripMenuItem.Size = new Size(108, 24);
            помещениеToolStripMenuItem.Text = "Помещение";
            // 
            // miCreateRoom
            // 
            miCreateRoom.Name = "miCreateRoom";
            miCreateRoom.Size = new Size(246, 26);
            miCreateRoom.Text = "Создание помещения";
            miCreateRoom.Click += miCreateRoom_Click;
            // 
            // объектыToolStripMenuItem
            // 
            объектыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miAddFurniture, miImportObj, miDeleteObject });
            объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            объектыToolStripMenuItem.Size = new Size(84, 24);
            объектыToolStripMenuItem.Text = "Объекты";
            // 
            // miAddFurniture
            // 
            miAddFurniture.Name = "miAddFurniture";
            miAddFurniture.Size = new Size(213, 26);
            miAddFurniture.Text = "Добавить Объект";
            miAddFurniture.Click += miAddFurniture_Click;
            // 
            // miImportObj
            // 
            miImportObj.Name = "miImportObj";
            miImportObj.Size = new Size(213, 26);
            miImportObj.Text = "Импорт Obj";
            miImportObj.Click += miImportObj_Click;
            // 
            // miDeleteObject
            // 
            miDeleteObject.Name = "miDeleteObject";
            miDeleteObject.Size = new Size(213, 26);
            miDeleteObject.Text = "Удалить объект";
            miDeleteObject.Click += miDeleteObject_Click;
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miResetCamera, miCeilingDisplay });
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(49, 24);
            видToolStripMenuItem.Text = "Вид";
            // 
            // miResetCamera
            // 
            miResetCamera.Name = "miResetCamera";
            miResetCamera.Size = new Size(235, 26);
            miResetCamera.Text = "Сброс камеры";
            miResetCamera.Click += miResetCamera_Click;
            // 
            // miCeilingDisplay
            // 
            miCeilingDisplay.Checked = true;
            miCeilingDisplay.CheckState = CheckState.Checked;
            miCeilingDisplay.Name = "miCeilingDisplay";
            miCeilingDisplay.Size = new Size(235, 26);
            miCeilingDisplay.Text = "Отобразить потолок";
            miCeilingDisplay.Click += miCeilingDisplay_Click;
            // 
            // настройкаЦветаToolStripMenuItem
            // 
            настройкаЦветаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miFloorColor, miCeilingColor, miLeftWallColor, miRightWallColor, miFrontWallColor, miBackWallColor, miObjectColor });
            настройкаЦветаToolStripMenuItem.Name = "настройкаЦветаToolStripMenuItem";
            настройкаЦветаToolStripMenuItem.Size = new Size(140, 24);
            настройкаЦветаToolStripMenuItem.Text = "Настройка цвета";
            // 
            // miFloorColor
            // 
            miFloorColor.Name = "miFloorColor";
            miFloorColor.Size = new Size(276, 26);
            miFloorColor.Text = "Цвет пола";
            // 
            // miCeilingColor
            // 
            miCeilingColor.Name = "miCeilingColor";
            miCeilingColor.Size = new Size(276, 26);
            miCeilingColor.Text = "Цвет потолка";
            // 
            // miLeftWallColor
            // 
            miLeftWallColor.Name = "miLeftWallColor";
            miLeftWallColor.Size = new Size(276, 26);
            miLeftWallColor.Text = "Цвет левой стены";
            // 
            // miRightWallColor
            // 
            miRightWallColor.Name = "miRightWallColor";
            miRightWallColor.Size = new Size(276, 26);
            miRightWallColor.Text = "Цвет правой стены";
            // 
            // miFrontWallColor
            // 
            miFrontWallColor.Name = "miFrontWallColor";
            miFrontWallColor.Size = new Size(276, 26);
            miFrontWallColor.Text = "Цвет передней стены";
            // 
            // miBackWallColor
            // 
            miBackWallColor.Name = "miBackWallColor";
            miBackWallColor.Size = new Size(276, 26);
            miBackWallColor.Text = "Цвет задней стены";
            // 
            // miObjectColor
            // 
            miObjectColor.Name = "miObjectColor";
            miObjectColor.Size = new Size(276, 26);
            miObjectColor.Text = "Цвет выбранного объекта";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1851, 815);
            Controls.Add(glControl1);
            Controls.Add(panelTools);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Модельер";
            Load += Form1_Load;
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTools;
        private OpenTK.GLControl.GLControl glControl1;
        private ListBox lstObjects;
        private PropertyGrid propertyGrid1;
        private Button btnEditRoom;
        private Button btnMoveSelected;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem miNewProject;
        private ToolStripMenuItem miOpenProject;
        private ToolStripMenuItem miSaveProject;
        private ToolStripMenuItem miExportPng;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem помещениеToolStripMenuItem;
        private ToolStripMenuItem miCreateRoom;
        private ToolStripMenuItem объектыToolStripMenuItem;
        private ToolStripMenuItem miImportObj;
        private ToolStripMenuItem miDeleteObject;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem miResetCamera;
        private Button btnRotateMode;
        private ToolStripMenuItem miAddFurniture;
        private ToolStripMenuItem miCeilingDisplay;
        private ToolStripMenuItem настройкаЦветаToolStripMenuItem;
        private ToolStripMenuItem miFloorColor;
        private ToolStripMenuItem miCeilingColor;
        private ToolStripMenuItem miLeftWallColor;
        private ToolStripMenuItem miRightWallColor;
        private ToolStripMenuItem miFrontWallColor;
        private ToolStripMenuItem miBackWallColor;
        private ToolStripMenuItem miObjectColor;
        private Label label2;
        private Label label1;
    }
}
