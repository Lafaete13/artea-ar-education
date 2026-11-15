# ARTEA 🧩
**Módulo de Comunicação Alternativa e Aumentativa (CAA) com Realidade Aumentada para crianças com TEA.**

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Vuforia](https://img.shields.io/badge/Vuforia_Engine-000000?style=for-the-badge&logo=vuforia&logoColor=white)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-brightgreen?style=for-the-badge)

## 📌 Sobre o Projeto
O **ARTEA** é um ecossistema tecnológico e assistivo desenvolvido para atuar na mitigação de barreiras de comunicação enfrentadas por crianças com Transtorno do Espectro Autista (TEA). 

Este repositório contém a implementação do **Módulo CAA**, que integra Realidade Aumentada (RA) baseada em marcadores tangíveis a dinâmicas de gamificação. Ao apontar o dispositivo móvel para as faces de um dodecágono físico impresso em 3D, o sistema renderiza avatares animados e áudios sincronizados correspondentes a emoções e condições de saúde, ancorando a atenção da criança e facilitando a expressão não verbal.

*Projeto de Conclusão de Curso (TCC) - Tecnologia em Sistemas para Internet | IFB Campus Brasília, 2026. Autores: Lafaete Dias Alves e Ana Paula Pereira Ribeiro.*

---

## 🚀 Funcionalidades e Fluxo do Aplicativo

O módulo foi projetado focando em **acessibilidade cognitiva** e **redução de sobrecarga sensorial**, utilizando tons suaves, baixa poluição visual e mecânicas previsíveis em todas as etapas do fluxo.

### 1. Menu Principal
A interface inicial do ecossistema ARTEA, que garante uma navegação direta e segura, fornecendo acesso rápido ao Módulo de Comunicação.
<br><img src="prints/tela_modulo (1).jpeg" width="250" alt="Tela de Módulo">

### 2. Seleção de Categorias
Permite à criança ou ao responsável escolher qual contexto de vocabulário assistivo deseja utilizar para o rastreamento em Realidade Aumentada: **Expressões, Emoções ou Saúde**.
<br><img src="prints/tela_categoria (2).jpeg" width="250" alt="Tela de Categoria">

### 3. Integração Tangível (Realidade Aumentada)
O núcleo do sistema. O motor gráfico identifica o marcador colado no **dodecágono físico 3D** e renderiza instantaneamente o avatar correspondente (ex: Mal-estar/Febre) sobreposto ao mundo real, acompanhado de feedback sonoro.
<br><img src="prints/dodecagono-avatar (3).jpeg" width="250" alt="Dodecágono com Avatar em RA">

### 4. Validação e Gamificação
Logo após a exibição do avatar em RA, o sistema dispara um quiz de múltipla escolha para validar a compreensão pedagógica da criança sobre o sentimento demonstrado.
<br><img src="prints/tela_gamificacao (4).jpeg" width="250" alt="Tela de Gamificação">

### 5. Sistema de Feedback Interativo
O aplicativo atua com base no reforço positivo, celebrando acertos com recompensas visuais e adotando uma abordagem de incentivo suave em caso de erro, evitando frustrações.
<br>
<img src="prints/tela_acerto (5).jpeg" width="250" alt="Feedback de Acerto"> &nbsp; &nbsp; <img src="prints/tela_erro (6).jpeg" width="250" alt="Feedback de Erro">
---

## 🛠️ Tecnologias Utilizadas

* **Motor Gráfico:** Unity 3D
* **Linguagem:** C# (Máquina de estados, controladores multimídia e lógica de gamificação)
* **Visão Computacional / RA:** Vuforia Engine SDK (Image Tracking e ancoragem espacial)
* **Hardware Auxiliar:** Dodecágono impresso em 3D como interface tangível

## ⚙️ Como Executar o Projeto

1. Certifique-se de ter o **Unity Hub** instalado com a versão da Unity recomendada pelo projeto.
2. Clone este repositório:
   ```bash
   git clone [https://github.com/Lafaete13/artea-ar-education.git](https://github.com/Lafaete13/artea-ar-education.git)


Abra o projeto via Unity Hub.

(Importante): Devido ao tamanho limite do GitHub, os pacotes comprimidos (.tgz) do Vuforia Engine foram ignorados pelo .gitignore. É necessário instalar o pacote do Vuforia via Package Manager > Add package from tarball... ou importá-lo pela Asset Store para compilar o sistema de AR.

Inicie a cena principal localizada na pasta Assets/Scenes.

📜 Licença e Autoria
Este projeto possui fins acadêmicos e assistivos.
Desenvolvido por Lafaete Dias Alves e Ana Paula Pereira Ribeiro. 
Orientação: Prof. Gustavo Henrique Dornelas de Deus.
