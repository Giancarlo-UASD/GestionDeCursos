public class Curso
{
    // Atributos privados
    private string codigoCurso;
    private string nombreCurso;

    public string CodigoCurso 
    { 
        get { return codigoCurso; } 
        private set { 
            if((value.Length < 2) || (String.IsNullOrEmpty(value))){
                Console.WriteLine("[Error] Nombre no Válido...");
                codigoCurso = "(Código de Curso no válido)";
            }else{
                codigoCurso = value; 
            }
        }
    }

    public string NombreCurso 
    { 
        get { return nombreCurso; } 
        private set { 
            if((value.Length < 2) || (String.IsNullOrEmpty(value))){
                Console.WriteLine("[Error] Nombre no Válido...");
                nombreCurso = "(Nombre de Curso no válido)";
            }else{
                nombreCurso = value; 
            }
        }
    }

    public Curso(string codigo, string nombre)
    {
        CodigoCurso = codigo;
        NombreCurso = nombre;
    }

    public void MostrarInformacion(){
        Console.WriteLine($"- Código: {CodigoCurso} | Materia: {NombreCurso}");
    }
}