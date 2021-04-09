using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_SAPR
{
    public static class GLHelper
    {
        public static void DrawLine3D(SharpGL.OpenGL gl, float startX, float startY, float startZ,
                                                         float endX, float endY, float endZ, System.Drawing.Color lineColor)
        {
            gl.Begin(SharpGL.OpenGL.GL_LINES);
            float cR = lineColor.R / 255.0f;
            float cG = lineColor.G / 255.0f;
            float cB = lineColor.B / 255.0f;
            gl.Color(cR, cG, cB);
            gl.Vertex(startX, startY, startZ);
            gl.Vertex(endX, endY, endZ);
            gl.End();
        }

        public static void DrawAxis3D(SharpGL.OpenGL gl, 
                                      float offsetX, float offsetY, float offsetZ,
                                      float minXvalue, float maxXvalue,
                                      float minYvalue, float maxYvalue,
                                      float minZvalue, float maxZvalue,
                                      float lineWidth, float capSize)
        {
            gl.LineWidth(lineWidth);

            // ось X
            DrawLine3D(gl, offsetX + minXvalue, offsetY, offsetZ,
                           offsetX + maxXvalue, offsetY, offsetZ, System.Drawing.Color.Coral);
            DrawLine3D(gl, offsetX + maxXvalue - capSize, offsetY + (capSize / 3), offsetZ,
                           offsetX + maxXvalue,           offsetY,                 offsetZ, System.Drawing.Color.Coral);
            DrawLine3D(gl, offsetX + maxXvalue - capSize, offsetY - (capSize / 3), offsetZ,
                           offsetX + maxXvalue,           offsetY,                 offsetZ, System.Drawing.Color.Coral);

            // ось Y
            gl.Color(0.0f, 1.0f, 0.0f);

            DrawLine3D(gl, offsetX, offsetY + minYvalue, offsetZ,
                           offsetX, offsetY + maxYvalue, offsetZ, System.Drawing.Color.Lime);
            DrawLine3D(gl, offsetX - (capSize / 3), offsetY + maxYvalue - capSize, offsetZ,
                           offsetX, offsetY + maxYvalue, offsetZ, System.Drawing.Color.Lime);
            DrawLine3D(gl, offsetX + (capSize / 3), offsetY + maxYvalue - capSize, offsetZ,
                           offsetX, offsetY + maxYvalue, offsetZ, System.Drawing.Color.Lime);

            // ось Z
            gl.Color(0.0f, 0.0f, 1.0f);

            DrawLine3D(gl, offsetX, offsetY, offsetZ + minZvalue,
                           offsetX, offsetY, offsetZ + maxZvalue, System.Drawing.Color.Navy);
            DrawLine3D(gl, offsetX, offsetY + (capSize / 3), offsetZ + maxZvalue - capSize,
                           offsetX, offsetY, offsetZ + maxZvalue, System.Drawing.Color.Navy);
            DrawLine3D(gl, offsetX, offsetY - (capSize / 3), offsetZ + maxZvalue - capSize,
                           offsetX, offsetY, offsetZ + maxZvalue, System.Drawing.Color.Navy);
        }

        public static void DrawBackground(SharpGL.OpenGL gl)
        {
            gl.Begin(SharpGL.OpenGL.GL_POLYGON);

            gl.Color(0.9f, 0.9f, 1.0f);
            gl.Vertex(-500, 30, -50f);
            gl.Vertex(500, 30, -50f);

            gl.Color(0.0f, 0.3f, 1.0f);
            gl.Vertex(500, -30, -50f);
            gl.Vertex(-500, -30, -50f);

            gl.End();
        }

        public static void DrawPiram(SharpGL.OpenGL gl, float width, float height, float depth,
                                     System.Drawing.Color polygonColor, System.Drawing.Color lineColor)
        {
            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, depth / 2);

            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2,  0f, -depth / 2);
            gl.Vertex(width / 2, 0f, depth / 2);

            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, -depth / 2);

            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_QUADS);
            gl.Vertex(-width / 2, 0.0f, depth / 2);
            gl.Vertex(width / 2, 0.0f, depth / 2);
            gl.Vertex(width / 2, 0.0f, -depth / 2);
            gl.Vertex(-width / 2, 0.0f, -depth / 2);
            gl.End();

            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.Vertex(width / 2, 0f, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height, 0.0f);
            gl.Vertex(-width / 2, 0f, depth / 2);
            gl.Vertex(-width / 2, 0f, -depth / 2);
            gl.End();            
        }

        public static void DrawSolids(SharpGL.OpenGL gl)
        {
            //...
        }

        public static void DrawNet(SharpGL.OpenGL gl, int total_cells, int cell_size)
        {
            for (int i = 0; i <= total_cells; i++)
            {
                int gap = cell_size * i;

                DrawLine3D(gl, 0, 0, gap, total_cells * cell_size, 0, gap, System.Drawing.Color.Red);
                DrawLine3D(gl, gap, 0, 0, gap, 0, total_cells * cell_size, System.Drawing.Color.Red);
            }
        }

        public static void DrawBox(SharpGL.OpenGL gl, float width, float height, float depth,
                                   System.Drawing.Color polygonColor, System.Drawing.Color lineColor)
        {
            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(0.0f,  height / 2, -depth / 2);
            gl.Vertex(0.0f,  height / 2,  depth / 2);
            gl.Vertex(0.0f, -height / 2,  depth / 2);
            gl.Vertex(0.0f, -height / 2, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(0.0f, height / 2, depth / 2);
            gl.Vertex(0.0f, height / 2, -depth / 2);
            gl.Vertex(width, height / 2,-depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(width, height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(0.0f,  -height / 2, depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);
            gl.Vertex(0.0f,  -height / 2, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(0.0f, height / 2, depth / 2);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.Vertex(0.0f, -height / 2, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            gl.Vertex(width, height / 2, -depth / 2);
            gl.Vertex(0.0f, height / 2, -depth / 2);
            gl.Vertex(0.0f, -height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);            
            gl.End();

            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height / 2, -depth / 2);
            gl.Vertex(0.0f, height / 2, depth / 2);
            gl.Vertex(0.0f, -height / 2, depth / 2);
            gl.Vertex(0.0f, -height / 2, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(0.0f, height / 2, depth / 2);
            gl.Vertex(0.0f, height / 2, -depth / 2);
            gl.Vertex(width, height / 2, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(width, height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, -height / 2, depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);
            gl.Vertex(0.0f, -height / 2, -depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, height / 2, depth / 2);
            gl.Vertex(width, height / 2, depth / 2);
            gl.Vertex(width, -height / 2, depth / 2);
            gl.Vertex(0.0f, -height / 2, depth / 2);
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            gl.Vertex(width, height / 2, -depth / 2);
            gl.Vertex(0.0f, height / 2, -depth / 2);
            gl.Vertex(0.0f, -height / 2, -depth / 2);
            gl.Vertex(width, -height / 2, -depth / 2);
            gl.End();
        }


        public static void DrawCylinder(SharpGL.OpenGL gl, float diameter1, float diameter2, float height,
                                        System.Drawing.Color polygonColor, System.Drawing.Color lineColor)
        {
            int ng = 12;

            List<Tuple<float, float>> list1 = new List<Tuple<float, float>>();
            List<Tuple<float, float>> list2 = new List<Tuple<float, float>>();

            for (int i = 0; i <= ng; i++)
            {
                float seta = (float)i * 360.0f / ng;

                float vx = (float)Math.Sin((Math.PI * seta / 180.0f)) * (diameter1 / 2);
                float vz = (float)Math.Cos((Math.PI * seta / 180.0f)) * (diameter1 / 2);
                list1.Add(new Tuple<float, float>(vx, vz));

                float vx2 = (float)Math.Sin((Math.PI * seta / 180.0f)) * (diameter2 / 2);
                float vz2 = (float)Math.Cos((Math.PI * seta / 180.0f)) * (diameter2 / 2);
                list2.Add(new Tuple<float, float>(vx2, vz2));
            }

            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            for (int i = 0; i < list1.Count; i++)
            {
                gl.Vertex(list1[i].Item1, 0f, list1[i].Item2);
            }
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_POLYGON);
            for (int i = list2.Count - 1; i >= 0; i--)
            {
                gl.Vertex(list2[i].Item1, height, list2[i].Item2);
            }
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_QUADS);
            for (int i = 0; i < list1.Count - 1; i++)
            {
                gl.Vertex(list1[i].Item1, 0f, list1[i].Item2);
                gl.Vertex(list2[i].Item1, height, list2[i].Item2);
                gl.Vertex(list2[i+1].Item1, height, list2[i+1].Item2);
                gl.Vertex(list1[i+1].Item1, 0f, list1[i+1].Item2);
            }
            gl.End();


            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < list1.Count; i++)
            {
                gl.Vertex(list1[i].Item1, 0f, list1[i].Item2);
            }
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            for (int i = list2.Count - 1; i >= 0; i--)
            {
                gl.Vertex(list2[i].Item1, height, list2[i].Item2);
            }
            gl.End();

            gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < list1.Count - 1; i++)
            {
                gl.Vertex(list1[i].Item1, 0f, list1[i].Item2);
                gl.Vertex(list2[i].Item1, height, list2[i].Item2);
                gl.Vertex(list2[i + 1].Item1, height, list2[i + 1].Item2);
                gl.Vertex(list1[i + 1].Item1, 0f, list1[i + 1].Item2);
            }
            gl.End();

        }

        public static void DrawSphere(SharpGL.OpenGL gl, float diameter, System.Drawing.Color polygonColor, System.Drawing.Color lineColor)
        {
            int sph_ng = 24; float sph_radius = diameter / 2;

            List<double[,]> slices = new List<double[,]>();

            double dPhi = 2 * Math.PI / sph_ng;
            double dPsi = 2 * Math.PI / sph_ng;
            for (int i = 0; i <= sph_ng; i++)
            {
                double[,] slice = new double[sph_ng + 1, 3];

                double Psi = -Math.PI + dPsi * i;

                for (int j = 0; j <= sph_ng; ++j)
                {
                    double Phi = dPhi * j;

                    double x = (sph_radius * Math.Cos(Phi));
                    double y = (sph_radius * Math.Sin(Phi)) * Math.Sin(Psi);
                    double z = (sph_radius * Math.Sin(Phi)) * Math.Cos(Psi);
                    slice[j, 0] = x; slice[j, 1] = y; slice[j, 2] = z;
                }
                slices.Add(slice);
            }

            float pR = polygonColor.R / 255.0f;
            float pG = polygonColor.G / 255.0f;
            float pB = polygonColor.B / 255.0f;
            gl.Color(pR, pG, pB);
            
            for (int i = 0; i < slices.Count - 1; i++)
            {
                for (int j = 0; j < sph_ng; ++j)
                {
                    gl.Begin(SharpGL.OpenGL.GL_QUADS);
                    gl.Vertex(slices[i][j, 0],         slices[i][j, 1],         slices[i][j, 2]);
                    gl.Vertex(slices[i + 1][j, 0],     slices[i + 1][j, 1],     slices[i + 1][j, 2]);
                    gl.Vertex(slices[i + 1][j + 1, 0], slices[i + 1][j + 1, 1], slices[i + 1][j + 1, 2]);
                    gl.Vertex(slices[i][j + 1, 0],     slices[i][j + 1, 1],     slices[i][j + 1, 2]);
                    gl.End();
                }
            }


            float lR = lineColor.R / 255.0f;
            float lG = lineColor.G / 255.0f;
            float lB = lineColor.B / 255.0f;
            gl.Color(lR, lG, lB);            
            
            for (int i = 0; i < slices.Count - 1; i++)
            {
                for (int j = 0; j < sph_ng; ++j)
                {
                    gl.Begin(SharpGL.OpenGL.GL_LINE_LOOP);
                    gl.Vertex(slices[i][j, 0], slices[i][j, 1], slices[i][j, 2]);
                    gl.Vertex(slices[i + 1][j, 0], slices[i + 1][j, 1], slices[i + 1][j, 2]);
                    gl.Vertex(slices[i + 1][j + 1, 0], slices[i + 1][j + 1, 1], slices[i + 1][j + 1, 2]);
                    gl.Vertex(slices[i][j + 1, 0], slices[i][j + 1, 1], slices[i][j + 1, 2]);
                    gl.End();
                }
            }
        }
    }
}
