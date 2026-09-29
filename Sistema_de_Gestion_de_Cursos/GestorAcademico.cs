public class GestorAcademico
{
    private List<Estudiante> estudiantes = new List<Estudiante>();
    private List<Curso> cursos = new List<Curso>();
    private List<Inscripcion> inscripciones = new List<Inscripcion>();

    public void RegistrarEstudiante(Estudiante nuevoEstudiante)
    {
        estudiantes.Add(nuevoEstudiante);
        Console.WriteLine($"\n[Éxito] Estudiante '{nuevoEstudiante.Nombre}' registrado con ID: {nuevoEstudiante.IdEstudiante}");
    }

    public void RegistrarCurso(Curso curso)
    {
        cursos.Add(curso);
        Console.WriteLine($"\n[Éxito] Curso '{curso.NombreCurso}' registrado correctamente.");
    }

    public bool InscribirEstudiante(string idEstudiante, string codigoCurso)
    {
        var estudiante = estudiantes.FirstOrDefault(e => e.IdEstudiante == idEstudiante);
        var curso = cursos.FirstOrDefault(c => c.CodigoCurso == codigoCurso);

        if (estudiante == null || curso == null)
        {
            Console.WriteLine("\n[Error] Estudiante o Curso no encontrado.");
            return false;
        }

        bool yaInscrito = inscripciones.Any(i => i.Estudiante.IdEstudiante == idEstudiante && i.Curso.CodigoCurso == codigoCurso);
        if (yaInscrito)
        {
            Console.WriteLine("\n[Aviso] El estudiante ya está inscrito en este curso.");
            return false;
        }

        // Se usa el constructor de Inscripcion
        inscripciones.Add(new Inscripcion(estudiante, curso, DateTime.Now));
        Console.WriteLine($"\n[Éxito] Estudiante '{estudiante.Nombre}' inscrito en '{curso.NombreCurso}'.");
        return true;
    }

    public void RetirarInscripcion(string idEstudiante, string codigoCurso)
    {
        int eliminados = inscripciones.RemoveAll(i => i.Estudiante.IdEstudiante == idEstudiante && i.Curso.CodigoCurso == codigoCurso);
        if (eliminados > 0)
        {
            Console.WriteLine("\n[Éxito] Inscripción retirada correctamente.");
        }
        else
        {
            Console.WriteLine("\n[Aviso] No se encontró una inscripción activa con esos datos.");
        }
    }

    public void ConsultarEstudiantesPorCurso(string codigoCurso)
    {
        var curso = cursos.FirstOrDefault(c => c.CodigoCurso == codigoCurso);
        if (curso == null)
        {
            Console.WriteLine("\n[Error] El curso especificado no existe.");
            return;
        }

        var listaEstudiantes = inscripciones
            .Where(i => i.Curso.CodigoCurso == codigoCurso)
            .Select(i => i.Estudiante)
            .ToList();

        Console.WriteLine($"\n=== ESTUDIANTES EN EL CURSO: {curso.NombreCurso} ({listaEstudiantes.Count}) ===");
        if (listaEstudiantes.Count == 0)
        {
            Console.WriteLine("(No hay estudiantes inscritos en este curso)");
            return;
        }

        foreach (var est in listaEstudiantes)
        {
            est.MostrarInformacion();
        }
    }

    public void ConsultarCursosPorEstudiante(string idEstudiante)
    {
        var estudiante = estudiantes.FirstOrDefault(e => e.IdEstudiante == idEstudiante);
        if (estudiante == null)
        {
            Console.WriteLine("\n[Error] El estudiante especificado no existe.");
            return;
        }

        var listaCursos = inscripciones
            .Where(i => i.Estudiante.IdEstudiante == idEstudiante)
            .Select(i => i.Curso)
            .ToList();

        Console.WriteLine($"\n=== CURSOS DEL ESTUDIANTE: {estudiante.Nombre} ({listaCursos.Count}) ===");
        if (listaCursos.Count == 0)
        {
            Console.WriteLine("(El estudiante no está inscrito en ningún curso)");
            return;
        }

        foreach (var cur in listaCursos)
        {
            cur.MostrarInformacion();
        }
    }

    public void CargarDatosAleatorios()
    {
        // 1. Crear y registrar cursos predefinidos
        var listaCursos = new List<Curso>
        {
            new Curso("MAT101", "Cálculo I"),
            new Curso("MAT102", "Cálculo II"),
            new Curso("MAT103", "Cálculo III"),
            new Curso("PROG101", "Programación I"),
            new Curso("PROG102", "Programación II"),
            new Curso("PROG103", "Programación III"),
            new Curso("FIS101", "Física General I"),
            new Curso("FIS102", "Física General II"),
            new Curso("FIS103", "Física General III"),
            new Curso("BD101", "Bases de Datos I"),
            new Curso("BD102", "Bases de Datos II"),
            new Curso("BD103", "Bases de Datos III"),
            new Curso("MAT201", "Análisis Real I"),
            new Curso("MAT202", "Análisis Real II"),
            new Curso("MAT203", "Análisis Real III"),
            new Curso("MAT203", "Lógica y Teoría de Conjuntos")
        };

        foreach (var curso in listaCursos)
        {
            if (!cursos.Any(c => c.CodigoCurso == curso.CodigoCurso))
                cursos.Add(curso);
        }

        // 2. Crear y registrar estudiantes predefinidos
        var listaEstudiantes = new List<Estudiante>
        {
            new Estudiante("Ana Gómez"),
            new Estudiante("Carlos Pérez"),
            new Estudiante("María Rodríguez"),
            new Estudiante("José Martínez"),
            new Estudiante("Lucía Fernández"),
            new Estudiante("Olga Álverez"),
            new Estudiante("John Aponte"),
            new Estudiante("Wilmer Sánchez"),
            new Estudiante("Adriana Betancourt"),
            new Estudiante("Ingrid Carreño"),
            new Estudiante("Jairo Castro"),
            new Estudiante("Sara Castro"),
            new Estudiante("Amelia Galindo"),
            new Estudiante("Miguel Durán"),
            new Estudiante("Ana Galván"),
            new Estudiante("Zulma Moran"),
            new Estudiante("Gustavo Lagos"),
            new Estudiante("Norberto Molina"),
            new Estudiante("July Moreno"),
            new Estudiante("Edgar Patiño")
        };

        foreach (var est in listaEstudiantes)
        {
            estudiantes.Add(est);
        }

        // 3. Generar inscripciones aleatorias evitando duplicados
        Random rand = new Random();
        int metaInscripciones = 50; // Cantidad deseada de inscripciones aleatorias
        int intentos = 0;

        while (inscripciones.Count < metaInscripciones && intentos < 1000)
        {
            intentos++;
            Estudiante estudianteAleatorio = listaEstudiantes[rand.Next(listaEstudiantes.Count)];
            Curso cursoAleatorio = listaCursos[rand.Next(listaCursos.Count)];

            bool yaInscrito = inscripciones.Any(i => i.Estudiante.IdEstudiante == estudianteAleatorio.IdEstudiante && i.Curso.CodigoCurso == cursoAleatorio.CodigoCurso);
            if (!yaInscrito)
            {
                inscripciones.Add(new Inscripcion(estudianteAleatorio, cursoAleatorio, DateTime.Now.AddDays(-rand.Next(1, 30))));
            }
        }
        Console.WriteLine("\n[Éxito] ¡Datos aleatorios cargados con éxito!");
    }

    public void MostrarResumen()
    {
        Console.WriteLine($"\n=== ESTUDIANTES REGISTRADOS ({estudiantes.Count}) ===");
        if (estudiantes.Count == 0) Console.WriteLine("(No hay estudiantes)");
        foreach (var e in estudiantes) 
            e.MostrarInformacion();

        Console.WriteLine($"\n=== CURSOS DISPONIBLES ({cursos.Count}) ===");
        if (cursos.Count == 0) Console.WriteLine("(No hay cursos)");
        foreach (var c in cursos) 
            c.MostrarInformacion();

        Console.WriteLine($"\n=== INSCRIPCIONES ACTIVAS ({inscripciones.Count}) ===");
        if (inscripciones.Count == 0) Console.WriteLine("(No hay inscripciones)");
        foreach (var i in inscripciones) 
            i.MostrarInformacion();
    }
}