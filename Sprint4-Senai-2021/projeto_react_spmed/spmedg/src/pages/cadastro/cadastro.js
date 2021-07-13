

// import { Component } from 'react'

// import "../../assets/css/style.css";
// import logoc from "../../assets/img/logo.jpeg";
// import perfil from "../../assets/img/Perfil.png";
// import cale from "../../assets/img/calendario.png";
// import relo from "../../assets/img/relogio.png";
// import medicon from "../../assets/img/medicoicon.png";
// import status from "../../assets/img/status.png";
// import especi from "../../assets/img/especiali.png";

// class Cadastro extends Component{
//     constructor(props){
//         super(props);
//         this.state = {
            
//         }
//     }
// }

// render(){
//     return(
//         <div id="fundo_f" >


// // <body class="body" >
// <tr key={consulta.IdConsulta}>
// <td>{new Date(consulta.dataConsulta).toLocaleDateString()}</td>
// <td>{new Date(consulta.dataConsulta).toLocaleTimeString()}</td>
// <td>{consulta.idMedicoNavigation.nomeMedico}</td>
// <td>{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</td>
// <td>{consulta.idProntuarioNavigation.nomePaciente}</td>                                                                        <td>{consulta.situacao}</td>
// <td>{consulta.descricao}</td>
// </tr>
            

//         </div>
//     <main class="estrutura_cm" >
        
//         <div>
//             <div class="estd_cm" >

//               <a href="#inicio"> <img id="logo_cm" src="img/SPMED (13) (1) 1.png" alt="Logo Sp Medical Group"> </a>
//               <input type="image" src="img/Perfil.png" id="imgper_cm" >   
//             </div> 

//             <h2 >Cadastro</h2>
//             <h3 id="h3" >Médico ou paciente ?</h3>

//             <select name="select" class="select" id="select">
//                 <option value="3">Médico</option>
//                 <option value="2">Paciente</option>
//             </select>

//         <div> 

//             <div id="3" class="formulario">
//                 <div id="paciente" >

//                     <form action="">

//                         <div class="input-field">
//                             <input type="text" name="nome" id="nome"
//                                 placeholder="Nome">
//                             <div class="linha"></div>
//                         </div>
                        
//                         <div class="input-field">
//                             <input type="email" name="email" id="email"
//                                 placeholder="Email">
//                             <div class="linha"></div>
//                         </div>

//                         <div class="input-field">
//                             <input type="text" name="password" id="password"
//                                 placeholder="Senha">
//                             <div class="linha"></div>
//                         </div>
                        
//                         <div class="input-field">
//                             <input type="text" name="CRM" id="CRM"
//                                 placeholder= "CRM">
//                             <div class="linha"></div>
//                         </div>
//                         <div class="input-field">
//                             <input type="text" name="CNPJ" id="CNPJ"
//                                 placeholder= "CNPJ">
//                                 <div class="linha"></div>
//                         </div>
                        
                        // <h4 id="h4" >Especialidade</h3>

                        // <select name="select" class="select" id="select2">
                        //     <option value="1">Acupuntura</option>
                        //     <option value="2">Anestesiologia</option>
                        //     <option value="3">Angiologia</option>
                        //     <option value="4">Cardiologia</option>
                        //     <option value="5">Cirurgia Cardiovascular</option>
                        //     <option value="6">Cirurgia da Mão</option>
                        //     <option value="7">Cirurgia do Aparelho Digestivo</option>
                        //     <option value="8">Cirurgia Geral</option>
                        //     <option value="9">Cirurgia Pediátrica</option>
                        //     <option value="10">Cirurgia Plástica</option>
                        //     <option value="11">Cirurgia Torácica</option>
                        //     <option value="12">Cirurgia Vascular</option>
                        //     <option value="13">Dermatologia</option>
                        //     <option value="14">Radioterapia</option>
                        //     <option value="15">Urologia</option>
                        //     <option value="16">Pediatria</option>
                        //     <option value="17">Psiquiatria</option>
                            
                        // </select>
                        
//                         <div  class="spa"></div>
//                         <input type="submit" value="Cadastre-se">
        
//                         <div class="ou" ><p>ou</p></div>
        
//                         <input type="submit" value="Login">
//                     </form>
//                 </div>  
//             </div>
//         </div>   

//         <!--  -->
       
//         <div id="2" class="formulario" style="display:none;">
//         <div id="medico" >
//             <form action="">

//                 <div class="input-field">
//                     <input type="text" name="nome" id="nome"
//                         placeholder="Nome">
//                     <div class="linha"></div>
//                 </div>
                
//                 <div class="input-field">
//                     <input type="email" name="email" id="email"
//                         placeholder="Email">
//                     <div class="linha"></div>
//                 </div>

//                 <div class="input-field">
//                     <input type="text" name="senha" id="senha"
//                         placeholder="Senha">
//                     <div class="linha"></div>
//                 </div>

//                 <div class="input-field">
//                     <input type="text" name="endereco" id="endereco"
//                         placeholder="Endereço">
//                     <div class="linha"></div>
//                 </div>

//                 <div class="input-field">
//                     <input type="text" name="RG" id="RG"
//                         placeholder="RG">
//                     <div class="linha"></div>
//                 </div>
                
//                 <div class="input-field">
//                     <input type="text" name="CPF" id="CPF"
//                         placeholder="CPF">
//                     <div class="linha"></div>
//                 </div>

//                 <div id="h4"> 
//                     <P>Data de nascimento</P>
//                 </div>
//             <div class="select3">

//                 <select name = "Dia" id="dia" required >
                    
//                     <option value="">Dia</option>
                         
//                 </select>
               
//                 <select id="mes" name="Mês" required >
                    
//                     <option>Mês </option>
//                     <option value="01">Janeiro  </option>
//                     <option value="02">Fevereiro</option>
//                     <option value="03">Março    </option>
//                     <option value="04">Abril    </option>
//                     <option value="05">Maio     </option>
//                     <option value="06">Junho    </option>
//                     <option value="07">Julho    </option>
//                     <option value="08">Agosto   </option>
//                     <option value="09">Setembro </option>
//                     <option value="10">Outubro  </option>
//                     <option value="11">Novembro </option>
//                     <option value="12">Dezembro </option>
  
//                 </select>	
                
//                 <select name = "Ano" id="ano" required >
//                     <option value="">Ano</option>
//                 </select>

//             </div>

//         <div>
            
//             <div id="h4"> 
//                 <P>Telefone</P>
//             </div>

           
//             <div class="tele">
//                 <select name = "ddd" id="ddd" required >
//                     <option value="">DDD</option>
//                 </select>

//                 <div class="telefone">
//                     <input type="text" name="tel" id="tel"
//                     placeholder="Telefone">
//                 </div>

//             </div>

            
//             <div  class="spa"></div>
//                 <input type="submit" value="Cadastre-se">

//                 <div class="ou" ><p>ou</p></div>

//                 <input type="submit" value="Login">
//             </form>
//         </div>  
//             </form>
//         </div>  
//     </div>      



            
//     </main>
// </body>
//         );
//     }
// }

// <script>
// var select = document.getElementById("select");
// var formularios = document.querySelectorAll('.formulario');

// select.onchange = function () {
//     for (var i = 0; i < formularios.length; i++) formularios[i].style.display = 'none';
//     var divID = select.options[select.selectedIndex].value;
//     var div = document.getElementById(divID);
//     div.style.display = 'block';
// };

// var ano = document.getElementById('ano');
// var dia= document.getElementById('dia');
//     for(var i = 1919; i <= 2021; i++){
//         ano.innerHTML+='<option value="'+i+'">'+i+'</option>'; }
            
//     for(var i = 1; i <= 31; i++){
//         dia.innerHTML+='<option value="'+i+'">'+i+'</option>'; }

// var ddd = document.getElementById('ddd');
//     for(var i = 11; i <= 99; i++){
//         ddd.innerHTML+='<option value="'+i+'">'+i+'</option>'; }

// </script>

// export default Cadastro;


  // Função que faz a chamada para a API para cadastrar um evento
  cadastrarEvento = (event) => {
    // Ignora o comportamento padrão do navegador
    event.preventDefault();
    // Define que a requisição está em andamento
    this.setState({ isLoading : true });

    // Define um evento que recebe os dados do state
    // É necessário converter o acessoLivre para int, para que o back-end consiga converter para bool ao cadastrar
    // Como o navegador envia o dado como string, não é possível converter para bool implicitamente
    let consulta = {
        paciente : this.state.idPaciente,
        medico : this.state.idMedico,
        dataConsulta : new Date( this.state.dataConsulta),
        situacao: this.state.situacao,
    };

    // Define a URL e o corpo da requisição
    axios.post('http://localhost:5000/api/Consultas', consulta, {
        headers : {
            'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
        }
    })

    // Verifica o retorno da requisição
    .then(resposta => {
        // Caso retorne 201,
        if (resposta.status === 201) {
            // exibe no console do navegador a mensagem abaixo
            console.log('Consulta cadastrado!');
            // e define que a requisição terminou
            this.setState({ isLoading : false });
        }
    })

    // Caso ocorra algum erro, exibe este erro no console do navegador
    .catch(erro => {
        console.log(erro);
        // e define que a requisição terminou
        this.setState({ isLoading : false });
    })

    // Então, atualiza a lista de eventos
    // sem o usuário precisar executar outra ação
    .then(this.buscarConsultas)
};
