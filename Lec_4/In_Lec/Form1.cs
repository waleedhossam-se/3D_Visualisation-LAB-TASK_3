using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace In_Lec
{
    public partial class Form1 : Form
    {
        Bitmap off;

        _3D_Model Cube = new _3D_Model();
       
        _3D_Model Cube2 = new _3D_Model();
        _3D_Model Cube3 = new _3D_Model();

        Camera cam = new Camera();

        int tt = 0;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
   
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            //   case Keys.X:
            //       Cube.RotX(1);
            //       break;
            //   case Keys.Y:
            //       Cube.RotY(1);
            //       break;
            //   case Keys.Z:
            //       Cube.RotZ(1);
            //       break;
            //   
            //   case Keys.Right:
            //       Cube.TransX(5);
            //       break;
            //   case Keys.Left:
            //       Cube.TransX(-5);
            //       break;

                case Keys.Up:
                 //       Cube.RotY(10);
                 //       Cube2.RotY(10);
                 //       Cube3.RotY(10);
                 //       GoBackwrd();
                  //  _3D_Point p1 = new _3D_Point(Cube2.L_3D_Pts[Cube2.L_Edges[9].i]);
                  //  _3D_Point p2 = new _3D_Point(Cube2.L_3D_Pts[Cube2.L_Edges[9].j]);
                  //  Cube.cam.TransformToOrigin_And_Rotate_And_Project( p2);
                    
                    Rotaty();
                    break;
           //    case Keys.Down:
           //          Cube.RotY(10);
           //            GoBackwrd();
           //         Cube.TransZ(-5);
           //         break;

                case Keys.Space:
                   // Cube.RotateAroundEdge(2, 1);

                 //  _3D_Point p1 = new _3D_Point(Cube2.L_3D_Pts[Cube2.L_Edges[9].i]);
                 //  _3D_Point p2 = new _3D_Point(Cube2.L_3D_Pts[Cube2.L_Edges[9].j]);

                    Cube3.RotateAroundEdge(8, 1);

                  //  Transformation.RotateArbitrary(Cube3.L_3D_Pts, p1, p2, 1);
                    break;
            }

            DrawDubble(this.CreateGraphics());
        }

        void GoBackwrd()
        {
            float diffX = cam.lookAt.X - cam.cop.X;
            float diffY = cam.lookAt.Y - cam.cop.Y;
            float diffZ = cam.lookAt.Z - cam.cop.Z;

            float step = 0.05f;

            cam.cop.X -= diffX * step;
            cam.cop.Y -= diffY * step;
            cam.cop.Z -= diffZ * step;

            cam.BuildNewSystem();
        }

        void GoTowrd()
        {
            float diffX = cam.lookAt.X - cam.cop.X;
            float diffY = cam.lookAt.Y - cam.cop.Y;
            float diffZ = cam.lookAt.Z - cam.cop.Z;

            float step = 0.05f;

            cam.cop.X += diffX * step;
            cam.cop.Y += diffY * step;
            cam.cop.Z += diffZ * step;

            cam.BuildNewSystem();



        }
        void Rotaty()
        {
            float th = (float)(2 * Math.PI / 180);
            float x_ = (float)(cam.cop.Z * Math.Sin(th) + cam.cop.X * Math.Cos(th));
            float y_ = cam.cop.Y;
            float z_ = (float)(cam.cop.Z * Math.Cos(th) - cam.cop.X * Math.Sin(th));

            cam.cop.X = x_;
            cam.cop.Z = z_;
            cam.BuildNewSystem();

        }

        void Rotatx()
        {
            float th = (float)(2 * Math.PI / 180);
            float x_ = cam.cop.X;
            float y_ = (float)(cam.cop.Y * Math.Cos(th) - cam.cop.Z * Math.Sin(th));
            float z_ = (float)(cam.cop.Y * Math.Sin(th) + cam.cop.Z * Math.Cos(th));


            cam.cop.Y = y_;
            cam.cop.Z = z_;
            cam.BuildNewSystem();

        }

        void UPleft()
        {

            cam.up.X += 0.01f;
            cam.up.Y += 0.01f;
            cam.up.Z += 0.01f;
            cam.BuildNewSystem();
        }
        
        void UPright()
        {

            cam.up.X -= 0.01f;
            cam.up.Y -= 0.01f;
            cam.up.Z -= 0.01f;
            cam.BuildNewSystem();
        }
        
        void Rotatz()
        {
            float th = (float)(2 * Math.PI / 180);

            float x_ = (float)(cam.cop.X * Math.Cos(th) - cam.cop.Y * Math.Sin(th));
            float y_ = (float)(cam.cop.X * Math.Sin(th) + cam.cop.Y * Math.Cos(th));
            float z_ = cam.cop.Z;

            cam.cop.X = x_;
            cam.cop.Y = y_;

            cam.BuildNewSystem();

        }

        void CreateCube(_3D_Model M, float XS, float YS, float ZS, Color vvv)
        {
            float[] vert = 
                            { 
                                    300,300,-100, 
                                    300,300, 100, 
                                    100,300, 100, 
                                    100,300, -100,
                                    300,100, -100,
                                    300,100, 100, 
                                    100,100, 100, 
                                    100,100, -100,
                                
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j]+XS, vert[j + 1]+YS, vert[j + 2]+ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv); //cl[i % 4]);

                j += 2;
            }
        }

        void CreateminiCube(_3D_Model M,float[] vert, float XS, float YS, float ZS, Color vvv)
        {
            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j] + XS, vert[j + 1] + YS, vert[j + 2] + ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], vvv); //cl[i % 4]);

                j += 2;
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width , this.ClientSize.Height);



            int cx = 900;
            int cy = 900;
            cam.ceneterX = (this.ClientSize.Width / 2);
            cam.ceneterY = (this.ClientSize.Height / 2);
            cam.cxScreen = cx;
            cam.cyScreen = cy;
            cam.BuildNewSystem();


            Cube.cam = cam;
            CreateCube(Cube , -200,-200,0 , Color.Yellow);

           
            
            float[] vert = 
                            { 
                                    -100,130,-25, //0
                                    -100,130, 25,  //1
                                    -180,130, 25,  //2
                                    -180,130, -25, //3
                                    -100,100, -25, //4
                                    -100,100, 25,  //5
                                    -180,100, 25,  //6
                                    -180,100, -25, //7                         
                                
                            };

           Cube2.cam = cam;
           CreateminiCube(Cube2, vert, 0, -100, 0, Color.Green);

           float[] vert1 =  {   
                                   -100,130,-25, //0
                                   -100,130, 25,  //1
                                   -180,130, 25,  //2
                                   -180,130, -25, //3
                                   -100,100, -25, //4
                                   -100,100, 25,  //5
                                   -180,100, 25,  //6
                                   -180,100, -25, //7
                                   
                            };

           Cube3.cam = cam;
           CreateminiCube(Cube3, vert1, -80, -100, 0, Color.Green);
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubble(e.Graphics);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);

            
            Cube.DrawYourSelf(g);
           Cube2.DrawYourSelf(g);
           Cube3.DrawYourSelf(g);
        }

        void DrawDubble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
