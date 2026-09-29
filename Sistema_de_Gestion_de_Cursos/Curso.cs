public class Curso
{
    // Atributos privados
    private string codigoCurso;
    private string nombreCurso;

    public string CodigoCurso 
    { 
        get { return codigoCurso; } 
        private set { codigoCurso = value; } 
    }

    public string NombreCurso 
    { 
        get { return nombreCurso; } 
        private set { nombreCurso = value; } 
    }

    public Curso(string codigo, string nombre)
    {
        CodigoCurso = codigo;
        NombreCurso = nombre;
    }
}