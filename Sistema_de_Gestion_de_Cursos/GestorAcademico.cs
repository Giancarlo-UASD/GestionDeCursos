public class GestorAcademico
{
    private List<Estudiante> estudiantes = new List<Estudiante>();
    private List<Curso> cursos = new List<Curso>();
    private List<Inscripcion> inscripciones = new List<Inscripcion>();

    public void RegistrarEstudiante(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }

    public void RegistrarCurso(Curso curso)
    {
        cursos.Add(curso);
    }

    public bool InscribirEstudiante(string idEstudiante, string codigoCurso)
    {
        var estudiante = estudiantes.FirstOrDefault(e => e.IdEstudiante == idEstudiante);
        var curso = cursos.FirstOrDefault(c => c.CodigoCurso == codigoCurso);

        if (estudiante == null || curso == null) return false;

        // Evitar duplicados
        bool yaInscrito = inscripciones.Any(i => i.Estudiante.IdEstudiante == idEstudiante && i.Curso.CodigoCurso == codigoCurso);
        if (yaInscrito) return false;

        inscripciones.Add(new Inscripcion
        {
            Estudiante = estudiante,
            Curso = curso,
            FechaInscripcion = DateTime.Now
        });
        return true;
    }

    public void RetirarInscripcion(string idEstudiante, string codigoCurso)
    {
        inscripciones.RemoveAll(i => i.Estudiante.IdEstudiante == idEstudiante && i.Curso.CodigoCurso == codigoCurso);
    }

    public IEnumerable<Estudiante> ObtenerEstudiantesPorCurso(string codigoCurso)
    {
        return inscripciones.Where(i => i.Curso.CodigoCurso == codigoCurso).Select(i => i.Estudiante);
    }
}