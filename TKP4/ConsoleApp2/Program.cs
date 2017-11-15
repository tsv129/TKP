using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace OpenGLNavigation2TaoCSharp
{
    sealed class Program
    {
        static float X = 0.0f;      
        static float Y = 0.0f;      
        static float Z = 0.0f;     
        static float rotX = 0.0f;  
        static float rotY = 0.0f;
        static float rotZ = 0.0f;   

        
        static void drawings()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix(); 
            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);         
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);          
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);     
            Gl.glTranslatef(X, Y, Z);   
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);           
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);         
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);         
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f); 
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 0.50f, 1.0f);      
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);       
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 1.0f, 0.50f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(3.0f, 3.0f, 3.0f);
            Gl.glVertex3f(3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, 3.0f, 3.0f);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.50f, 0.50f);
            Gl.glVertex3f(3.0f, -3.0f, 3.0f);
            Gl.glVertex3f(3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, -3.0f);
            Gl.glVertex3f(-3.0f, -3.0f, 3.0f);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);  
            Glut.glutPostRedisplay();         
            Gl.glPopMatrix();                   
            Glut.glutSwapBuffers();
        }
        
        static void init()
        {
            Gl.glShadeModel(Gl.GL_SMOOTH);   
            Gl.glClearColor(0, 0, 0, 0.0f);   
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //Gl.glClearDepth(1.0f);         
            Gl.glEnable(Gl.GL_DEPTH_TEST);  
            Gl.glDepthFunc(Gl.GL_LEQUAL);  
            //Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
        }
             
        
        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("Tkachuk lab");
            init();
            Glut.glutDisplayFunc(drawings);
            Glut.glutMainLoop();
        }
    }
}