using System;

 
namespace SistemaEscolar
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Turma { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
 
        public Aluno(string nome, string turma, double nota1, double nota2)
        {
            this.Nome = nome;
            this.Turma = turma;
            this.Nota1 = nota1;
            this.Nota2 = nota2;
        }
 
        public void MostrarAlunos()
        {
            Console.WriteLine($"O Aluno {Nome} da turma {Turma} teve como primeira nota: {Nota1} e como segunda nota: {Nota2}");
        }
 
        public void CalculoMedia()
        {
            if (Nota1 < 0 || Nota1 > 20 || Nota2 < 0 || Nota2 > 20)
            {
                Console.WriteLine("Nota Inválida");
            }
            else
            {
                double media = (Nota1 + Nota2) / 2;
                Console.WriteLine($"A média é: {media}");
            }
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno1 = new Aluno("Luís", "A", 19.2, 16.7);
 
            aluno1.MostrarAlunos();
            aluno1.CalculoMedia();
        }
    }
}
 