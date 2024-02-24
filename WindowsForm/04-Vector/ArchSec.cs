using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clase_Vector
{
  class ArchSec
  {
    private string NArch;
    private FileStream stream;
    private BinaryWriter writer1;
    private BinaryReader reader1;

    public ArchSec()
    {
      NArch = "";
    }
    public void Abrir_Grabar(string Narch1)
    {
      NArch = Narch1;
      stream = new FileStream(NArch, FileMode.CreateNew, FileAccess.Write);
      writer1 = new BinaryWriter(stream);
    }
    public void Grabar(int dato)
    {
      writer1.Write(dato);
    }

    public void Cerrar_Grabar()
    {
      writer1.Close();
      stream.Close();
    }
    public void Abrir_Leer(string Narch1)
    {
      NArch = Narch1;
      stream = new FileStream(NArch, FileMode.Open, FileAccess.Read);
      reader1 = new BinaryReader(stream);
    }
    public int Leer()
    {
      return reader1.ReadInt32();
    }
    public void Cerrar_Leer()
    {
      reader1.Close();
      stream.Close();
    }
    public bool Verif_Fin()
    {
      return stream.Position == stream.Length;
    }
  }
}
