# MyCOLL
PROJETO: MyCOLL - Plataforma de Colecionáveis
ALUNO: Guilherme Farias Costa

--- INSTRUÇÕES DE BASE DE DADOS ---
O ficheiro "BaseDeDadosMyCOLL.sql", encontra-se na pasta "BaseDeDados" e pode ser executado no SQL Server.

--- CONNECTION STRING ---
Verifique o ficheiro appsettings.json na API. 
Por defeito está configurado para: (localdb)\mssqllocaldb

--- CREDENCIAIS DE TESTE ---
Para testar as funcionalidades, utilize estes utilizadores já criados (ou crie novos):

1. ADMINISTRADOR (Gerir loja - MyCOLL.Admin):
   Email: admin@mycoll.com
   Pass:  Admin@123

1. FUNCIONÁRIO (Gerir loja - MyCOLL.Admin):
   Email: gui@email.com
   Pass:  Gui123@

3. FORNECEDOR (Para gerir produtos e vendas):
   Email: braga@email.com
   Pass:  Braga123@

4. CLIENTE (Para fazer compras):
   Email: rod@email.com
   Pass:  Rod123@

--- COMO EXECUTAR ---
1. Definir "MyCOLL.API" como Startup Project e iniciar.
2. Iniciar o Frontend "MyCOLL.Web" (ou App).
