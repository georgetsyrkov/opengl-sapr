using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_SAPR
{
    public partial class Form1 : Form
    {
        private float axisRotateX = 0f;
        private float axisRotateY = 0f;
        private float axisRotateZ = 0f;

        private bool isRotating = false;
        private bool isMoving = false;
        private bool isZooming = false;

        private int pressedMouseX = 0;
        private int pressedMouseY = 0;

        private float movedX = 0;
        private float movedY = 0;

        private float scaleFactor = 1;


        private bool doDrawAxis = true;
        private bool doDrawDefault = false;
        private bool doDrawSolids = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void glView1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            SharpGL.OpenGL gl = this.glView1.OpenGL;

            gl.Clear(SharpGL.OpenGL.GL_COLOR_BUFFER_BIT | SharpGL.OpenGL.GL_DEPTH_BUFFER_BIT);
            //gl.ClearColor(1f, 1f, 1f, 1f);
            gl.LoadIdentity();

            

            gl.Translate(0.0f, 0.0f, -12.0f);

            GLHelper.DrawBackground(gl);

            float transX = movedX / 20;
            float transY = movedY / 20;

            gl.Translate(transX, transY, 0.0f);

            gl.Rotate(axisRotateX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(axisRotateY, 0.0f, 1.0f, 0.0f);
            gl.Rotate(axisRotateZ, 0.0f, 0.0f, 1.0f);

            gl.Scale(scaleFactor, scaleFactor, scaleFactor);

            if (doDrawDefault)
            {
                //GLHelper.DrawNet(gl, 100, 5);
            }

            if (doDrawAxis)
            {
                GLHelper.DrawAxis3D(gl, 0, 0, 0,
                                        -3, 10,
                                        -3, 10,
                                        -3, 10,
                                        3, 1);
            }

            if (doDrawSolids)
            {
                //...
                GLHelper.DrawBox(gl, 10, 4, 4, Color.Orange, Color.OrangeRed);

                gl.Translate(5.0f, 3.0f, 0.0f);
                GLHelper.DrawPiram(gl, 10, 3, 4, System.Drawing.Color.DarkGreen, System.Drawing.Color.LightGreen);

                gl.Translate(-2.5f, 4.0f, 0.0f);
                GLHelper.DrawCylinder(gl, 5, 5, 7,  Color.PaleVioletRed, Color.MediumVioletRed);

                gl.Translate(0.0f, 8.0f, 0.0f);
                GLHelper.DrawCylinder(gl, 5, 1, 4, Color.Chocolate, Color.Red);

                gl.Translate(0.0f, 5.0f, 0.0f);
                GLHelper.DrawSphere(gl, 3, Color.LightBlue, Color.Blue);
            }

            gl.LoadIdentity();
        }

        private void glView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { this.isRotating = true; }
            if (e.Button == MouseButtons.Right) { this.isMoving = true; }
            if (e.Button == MouseButtons.Middle) { this.isZooming = true; }

            pressedMouseX = e.X;
            pressedMouseY = e.Y;
        }

        private void glView1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isRotating = false; 
            this.isMoving = false; 
            this.isZooming = false; 
        }

        private void glView1_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaX = pressedMouseX - e.X;
            int deltaY = pressedMouseY - e.Y;

            if (this.isMoving)
            {
                movedX = movedX - deltaX;
                movedY = movedY + deltaY;
            }
            if (this.isRotating)
            {
                axisRotateX = axisRotateX - deltaY / 2;
                axisRotateY -= deltaX / 2;
            }
            if (this.isZooming)
            {
                scaleFactor += deltaY * 0.01f;
            }

            pressedMouseX = e.X;
            pressedMouseY = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doDrawAxis = !doDrawAxis;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doDrawDefault = !doDrawDefault;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doDrawSolids = !doDrawSolids;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SharpGL.OpenGL gl = this.glView1.OpenGL;
            
            int[] ttt = new int[16];
            gl.GetInteger(SharpGL.OpenGL.GL_MAX_ELEMENTS_VERTICES, ttt);// Enable()

            string lll = $"{ttt[0]}{System.Environment.NewLine}";
            lll += $"{ttt[1]}{System.Environment.NewLine}";
            lll += $"{ttt[2]}{System.Environment.NewLine}";
            lll += $"{ttt[3]}{System.Environment.NewLine}";
            lll += $"{ttt[4]}{System.Environment.NewLine}";
            lll += $"{ttt[5]}{System.Environment.NewLine}";

            MessageBox.Show(lll);
        }
    }
}
