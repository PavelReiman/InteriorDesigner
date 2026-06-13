using InteriorDesigner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteriorDesigner
{
    public partial class RoomForm : Form
    {
        public Room Room { get; private set; }

        public RoomForm()
        {
            InitializeComponent();

            Room = new Room();
        }

        private void btnCreate_Click(
            object sender,
            EventArgs e)
        {
            Room.Width =
                (float)numWidth.Value;

            Room.Height =
                (float)numHeight.Value;

            Room.Length =
                (float)numLength.Value;

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private void cmbTemplates_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            switch (cmbTemplates.SelectedIndex)
            {
                case 0: // Однокомнатная

                    numWidth.Value = 8;
                    numLength.Value = 6;
                    numHeight.Value = 2;
                    break;

                case 1: // Двухкомнатная

                    numWidth.Value = 12;
                    numLength.Value = 8;
                    numHeight.Value = 2;
                    break;

                case 2: // Офис

                    numWidth.Value = 15;
                    numLength.Value = 10;
                    numHeight.Value = 2;
                    break;

                case 3: // Студия

                    numWidth.Value = 10;
                    numLength.Value = 10;
                    numHeight.Value = 2;
                    break;
            }
        }
    }
}
