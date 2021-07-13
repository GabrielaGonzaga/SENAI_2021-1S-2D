import { React, Component } from 'react';
import axios from 'axios';

//IMAGENS
import logopm from '../../assets/img/logopm.png';
import perfil from '../../assets/img/perfil.png';
import calendario from '../../assets/img/calendario.png';
import relogio from '../../assets/img/relogio.png';
import paciente from '../../assets/img/paciicon.png';
import status from '../../assets/img/status.png';
import especialidade from '../../assets/img/especiali.png';
// import login from '../home/login';


class medicos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
            nomeUsuario : '',
            idConsulta : 2,
            idPaciente :0,
            idMedico : 0,
            foto:'',
            dataConsulta: '',
            situacao: ''
        }
    }
    buscarConsultas = () => {
        
        axios('http://localhost:5000/api/consultas/meuspacientes', {
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

    atualizaEstadoTitulo = async (campo) => {
        await this.setState({ situacao : campo.target.value })
        console.log(this.state.situacao)
    };

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
            
            <div className="estrutura_lm">
                
                <div className="dis1">
                        <img src={perfil} id="ftperfil" alt="Imagem perfil"/>
                        {/* <input type="file" id="ftperfil" onblur="carregarFoto(this.value.foto)"></input> */}
                        <div className="colu">
                        <div >
                            { this.state.listaConsultas.map((consulta)=> {
                                        return(     
                                            <h5 >{consulta.idMedicoNavigation.nome}</h5> 
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
                                    <table className="container">
                                        <div id="rel">
                                            <img  id="icones" src={calendario} alt="icone calendario"/> 
                                            <p id="ps"> {new Date(consulta.dataConsulta).toLocaleDateString()}</p>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={relogio} alt="icone relógio"/> 
                                            <p id="ps">{consulta.horaConsulta}</p>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={paciente} alt="icone paciente"/> 
                                            <p id="ps">{consulta.idPacienteNavigation.nome }</p>
                                        </div>

                                        <div id="rel">
                                            <img  id="iconesm" src={status} alt="icone realizada"/> 
                                            <select onSubmit={this.atualizaEstadoTitulo} className="selectm" id="select">
                                                <option value="Realizada">Realizada</option>
                                                <option value="Agendada">Agendada</option>
                                                <option value="Cancelada">Cancelada</option>    
                                                <p>{consulta.situacao}</p>
                                            </select>
                                            <button type="submit" id="situb" value="novaconsulta">ok</button>
                                        </div>

                                        <div id="rel">
                                            <img  id="icones" src={especialidade} alt="icone especialidade"/> 
                                            <p id="ps">Cardiologia</p>
                                        </div>  
                                    </table>
                            
                                </div>             
                           

                           //<select name="select" class="select" id="select">
                           //                 <option value="3">Médico</option>
                           //                 <option value="2">Paciente</option>
                           //             </select>
                                      
                        );
                    })
                }
            </div>
        </div>
        </div>  
        </div>
        );
    }
}

export default medicos;