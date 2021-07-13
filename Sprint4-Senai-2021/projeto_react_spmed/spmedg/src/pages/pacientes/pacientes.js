import { React, Component } from 'react';
import axios from 'axios';

//IMAGENS
import logopm from '../../assets/img/logopm.png';
import perfil from '../../assets/img/perfil.png';
import calendario from '../../assets/img/calendario.png';
import relogio from '../../assets/img/relogio.png';
import status from '../../assets/img/status.png';
import medico from '../../assets/img/medicon.png';
import especialidade from '../../assets/img/especiali.png';


class pacientes extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
            nome: '',
            idConsulta : 2,
            idPaciente :0,
            idMedico : 0,
            horaConsulta:'',
            dataConsulta: '',
            situacao: ''
        }
    }

    buscarConsultas = () => {
        
        axios('http://localhost:5000/api/consultas/minhasconsultas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // Caso a requisição retorne um status code 200,
            if (resposta.status === 200) {
                // atualiza o state listaEventos com os dados obtidos
                this.setState({ listaConsultas : resposta.data })
                // e mostra no console do navegador a lista de eventos
                console.log(this.state.listaConsultas);
            }
        })
        // Caso ocorra algum erro, mostra no console do navegador
        .catch(erro => console.log(erro))
    }

    componentDidMount(){
        this.buscarConsultas();
    };

    render(){
        return(
            <div>
                <header>
                       
                        <div className="cabecalho">
                        <div className="logo" >
                            <a><img id="imgl" src={logopm} alt="Logo SP Medical Group"/></a>
                        </div>
        
                    <div className="menu">                       
                        <div className="lemenu">
                            <a href=""><button id="m" >Início</button></a>
                            <a href=""><button id="m" >Especialidades</button></a>
                            <a href=""><button id="m" >Contatos</button></a>
                        </div>       
                    </div>
        
                
                    <nav>
                        <input type="checkbox" id="check"/>
                            <label htmlFor="check" className="checkbtn" id="check1">
                                <i className="fas fa-bars"></i>
                            </label>
                        <ul>
                            <div className="menu12" >
                                <li id="mic1"><a href="#">Minhas consultas</a></li>
                                <li id="mic"><a href="#">Minha Conta</a></li>
                                <div className="linha_m"></div>
                            <li><a href="#"  className="vertical-menu">Eu</a></li>
                           </div>
                        </ul>
                    </nav>
                    <section></section>
                    </div>
                </header>
          
            
            <div className="dis">
            
                <main className="estrutura_lm">
                
                <div className="dis1">
                        <img src={perfil} id="ftperfil" alt="Imagem perfil"/>
                        {/* <input type="file" id="ftperfil" onblur="carregarFoto(this.value.foto)"></input> */}
                        <div className="colu">
                            <div >{ this.state.listaConsultas.map((consulta)=> {
                                        return(     
                                            <h5>{consulta.idPacienteNavigation.nome}</h5>
                                        )
                                    })
                                }
                            </div>
                            <h6>Suas consultas</h6>
                        </div>
                    </div>

                    <div>
                        <input id="pes" type="text" placeholder="Nome"></input>
                        <button><div id="lupa"></div></button>    
                    </div>
   
    <div className="wrap">
         {
            this.state.listaConsultas.map((consulta) => {
            return(
                        
                            <div className="coln">
                                    <div className="container">
                                        <div id="rel">
                                            <img  id="icones" src={calendario} alt="icone calendario"/> 
                                            <td id="ps"> {new Date(consulta.dataConsulta).toLocaleDateString()}</td>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={relogio} alt="icone relógio"/> 
                                            <p id="ps">{consulta.horaConsulta}</p>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={medico} alt="icone médico"/> 
                                            <p id="pn" >{consulta.idMedicoNavigation.nome }</p>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={status} alt="icone realizada"/> 
                                            <p id="ps"><td>{consulta.situacao}</td></p>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={especialidade} alt="icone especialidade"/> 
                                            <p id="ps">{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</p>
                                        </div>  
                                    </div>
                            
                                </div>             
                        );
                    })
                }
            </div>
        </main>
        </div>  
        </div>
        );
    }
}

export default pacientes;