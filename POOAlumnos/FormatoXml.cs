using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace POOAlumnos
{
    public class FormatoXml : Formato
    {
        public override void Add(Alumno alumno)
        {
            var path = "alumnos.xml";
            try
            {
                if (File.Exists(path))
                {
                    /*
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.SelectSingleNode("ArrayOfAlumno");

                    XmlElement newElement = doc.CreateElement("Alumno");
                    StringWriter sw = new StringWriter();
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Alumno));
                    xSeriz.Serialize(sw, alumno);
                    root.AppendChild(newElement);
                    doc.Save(path);

                    /*
                    XmlSerializer ser = new XmlSerializer(typeof(XmlNode));
                    XmlNode myNode = new XmlDocument().CreateNode(XmlNodeType.Element, "Alumno", "ns");
                    myNode.InnerText = "Hello Node";
                    FileStream fs1 = new FileStream(path, FileMode.Append);
                    ser.Serialize(fs1, myNode);*/
                }
                else
                {
                    List<Alumno> alumnos = new List<Alumno>();
                    XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
                    FileStream fs1 = new FileStream(path, FileMode.Create);
                    alumnos.Add(alumno);
                    xSeriz.Serialize(fs1, alumno);
                    fs1.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
