using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MouseJiggleApp
{
    public partial class frmMouseJiggle : Form
    {
        public frmMouseJiggle()
        {
            InitializeComponent();
        }

        private Thread jiggleThread;
        private bool doJiggle = false;

        private void btnStart_Click(object sender, EventArgs e)
        {
            doJiggle = true;
            jiggleThread = new Thread(DoTheJiggle);
            jiggleThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            doJiggle = false;
            MessageBox.Show("Jiggling has stopped!");
        }

        private void DoTheJiggle()
        {
            while (doJiggle)
            {
                Point pt = Cursor.Position;

                int moveUp = 0;

                Random rnd = new Random();
                int movement = rnd.Next(1, 2);
                switch (movement)
                {
                    case 1:
                        //Move up
                        moveUp = -1;
                        break;
                    case 2:
                        //Move down
                        moveUp = 1;
                        break;
                }

                pt.Y += moveUp;

                Cursor.Position = pt;
                Thread.Sleep(1000);
            }
        }
    }
}
