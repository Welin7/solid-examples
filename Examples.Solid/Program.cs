// See https://aka.ms/new-console-template for more information
using SolidExamples.Correcoes;
using SolidExamples.Violacoes;

Console.WriteLine("=== EXEMPLOS VIOLANDO SOLID ===");
SRP_Violacao.Executar();
// OCP_Violacao.Executar();
// LSP_Violacao.Executar();
// ISP_Violacao.Executar();
// DIP_Violacao.Executar();

Console.WriteLine("\n=== EXEMPLOS CORRIGIDOS COM SOLID ===");
SRP_Correcao.Executar();
// OCP_Correcao.Executar();
// LSP_Correcao.Executar();
// ISP_Correcao.Executar();
// DIP_Correcao.Executar();
