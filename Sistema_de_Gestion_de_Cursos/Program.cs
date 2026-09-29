using System;

bool salir = false;

//Primero vamos a crear unos cuantos estudiantes, cursos e inscripciones
GestorAcademico gestor = new GestorAcademico();

while (!salir)
{
    Console.Clear();
    Console.WriteLine("\x1b[3J");
    Console.WriteLine("=========================================");
    Console.WriteLine("     SISTEMA DE GESTIÓN DE CURSOS        ");
    Console.WriteLine("=========================================");
    Console.WriteLine("1. Registrar nuevo estudiante");
    Console.WriteLine("2. Registrar nuevo curso");
    Console.WriteLine("3. Inscribir estudiante en un curso");
    Console.WriteLine("4. Retirar inscripción");
    Console.WriteLine("5. Consultar estudiantes por curso");
    Console.WriteLine("6. Consultar cursos por estudiante");
    Console.WriteLine("7. Cargar datos aleatorios de prueba");
    Console.WriteLine("8. Mostrar resumen general");
    Console.WriteLine("9. Salir");
    Console.Write("\nSeleccione una opción (1-9): ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("\nIngrese Nombre del estudiante: ");
            string nomEst = Console.ReadLine();
            gestor.RegistrarEstudiante(nomEst); 
            break;

        case "2":
            Console.Write("\nIngrese Código del curso: ");
            string codCur = Console.ReadLine();
            Console.Write("Ingrese Nombre del curso: ");
            string nomCur = Console.ReadLine();
            gestor.RegistrarCurso(new Curso(codCur, nomCur));
            break;

        case "3":
            Console.Write("\nIngrese ID del estudiante a inscribir (ej. E001): ");
            string idIns = Console.ReadLine();
            Console.Write("Ingrese Código del curso: ");
            string codIns = Console.ReadLine();
            gestor.InscribirEstudiante(idIns, codIns);
            break;

        case "4":
            Console.Write("\nIngrese ID del estudiante a retirar: ");
            string idRet = Console.ReadLine();
            Console.Write("Ingrese Código del curso del que se retira: ");
            string codRet = Console.ReadLine();
            gestor.RetirarInscripcion(idRet, codRet);
            break;

        case "5":
            Console.Write("\nIngrese el Código del curso a consultar: ");
            string codBusqueda = Console.ReadLine();
            gestor.ConsultarEstudiantesPorCurso(codBusqueda);
            break;

        case "6":
            Console.Write("\nIngrese el ID del estudiante a consultar (ej. E001): ");
            string idBusqueda = Console.ReadLine();
            gestor.ConsultarCursosPorEstudiante(idBusqueda);
            break;

        case "7":
            gestor.CargarDatosAleatorios();
            break;

        case "8":
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            gestor.MostrarResumen();
            break;

        case "9":
            salir = true;
            Console.WriteLine("\n¡Gracias por usar el sistema! Saliendo...");
            break;

        default:
            Console.WriteLine("\n[Error] Opción inválida. Intente de nuevo.");
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}