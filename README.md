# Hotel Assistant (Agente Azure OpenAI)

Descrição
\
Projeto ASP.NET com componentes Razor e integração com Azure OpenAI usando Microsoft Agent Framework. O agente realiza reservas, lista quartos disponíveis, mostra descrições e cancela reservas.

Pré-requisitos
\
- .NET 8+ SDK instalado
- Conta e recurso do Azure OpenAI configurado
- Variáveis de ambiente configuradas (ver abaixo)

Variáveis de ambiente
\
Defina as variáveis no sistema ou em um arquivo `.env` carregado pelo seu ambiente:
- `AZURE_OPENAI_ENDPOINT` — URL do endpoint do Azure OpenAI - encontra-se no foundry
- `AZURE_OPENAI_DEPLOYMENT_NAME` — (opcional) nome da implantação (padrão: `gpt-4.1-mini`) 
- `AZURE_API_KEY` — chave de API do Azure, encontra-se também no foundry

