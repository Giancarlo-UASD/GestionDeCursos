public class Inscripcion
{
    // Atributos privados
    private Estudiante estudiante;
    private Curso curso;
    private DateTime fechaInscripcion;

    public Estudiante Estudiante 
    { 
        get { return estudiante; } 
        private set { estudiante = value; } 
    }

    public Curso Curso 
    { 
        get { return curso; } 
        private set { curso = value; } 
    }

    public DateTime FechaInscripcion 
    { 
        get { return fechaInscripcion; } 
        private set { fechaInscripcion = value; } 
    }

    public Inscripcion(Estudiante est, Curso cur, DateTime fecha)
    {
        Estudiante = est;
        Curso = cur;
        FechaInscripcion = fecha;
    }
}