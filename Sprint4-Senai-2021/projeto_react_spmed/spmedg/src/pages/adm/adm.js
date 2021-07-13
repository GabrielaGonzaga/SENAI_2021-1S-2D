import { React, Component } from 'react';
import axios from 'axios';
// import { parseJwt, usuarioAutenticado } from '../../services/auth';


//IMAGENS
// import style from '../../assets/css/style.css'
import logopm from '../../assets/img/logopm.png';
import perfil from '../../assets/img/perfil.png';
import medico from '../../assets/img/medicon.png';
import calendario from '../../assets/img/calendario.png';
import relogio from '../../assets/img/relogio.png';
import paciente from '../../assets/img/paciicon.png';
import status from '../../assets/img/status.png';
import especialidade from '../../assets/img/especiali.png';
import x from '../../assets/img/x.png';



// import login from '../home/login';




class adm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
            nome: '',
            idConsulta: 0,
            idPaciente: 0,
            idMedico: 0,
            horaConsulta:'',
            dataConsulta: '',
            situacao: ''
        }
    }




    buscarConsultas = () => {
        console.log('buscando consultas')
        axios('http://localhost:5000/api/consultas', {
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


    // Função que faz a chamada para a API para cadastrar um evento
    cadastrarConsulta = (campo) => {

        // Ignora o comportamento padrão do navegador
        campo.preventDefault();
        // Define que a requisição está em andamento
        this.setState({ isLoading: true });

        // Define um evento que recebe os dados do state
        // É necessário converter o acessoLivre para int, para que o back-end consiga converter para bool ao cadastrar
        // Como o navegador envia o dado como string, não é possível converter para bool implicitamente
        let consulta = {
            paciente: this.state.idPaciente,
            medico: this.state.idMedico,
            dataConsulta: new Date(this.state.dataConsulta),
            situacao: this.state.situacao,
        };

        // Define a URL e o corpo da requisição
        axios.post('http://localhost:5000/api/Consultas', consulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            // Verifica o retorno da requisição
            .then(resposta => {
                // Caso retorne 201,
                if (resposta.status === 201) {
                    // exibe no console do navegador a mensagem abaixo
                    console.log('Consulta cadastrado!');
                    // e define que a requisição terminou
                    this.setState({ isLoading: false });
                }
            })

            // Caso ocorra algum erro, exibe este erro no console do navegador
            .catch(erro => {
                console.log(erro);
                // e define que a requisição terminou
                this.setState({ isLoading: false });
            })

            // Então, atualiza a lista de eventos
            // sem o usuário precisar executar outra ação
            .then(this.buscarConsultas)
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    };

    componentDidMount() {
        this.buscarConsultas();
    };

    render() {
        return (
            <div>
                <header>

                    <div className="cabecalho">
                        <div className="logo" >
                            <a><img id="imgl" src={logopm} alt="Logo SP Medical Group" /></a>
                        </div>

                        <div className="menu">
                            <div className="lemenu">
                                <a href=""><button id="m" >Início</button></a>
                                <a href=""><button id="m" >Especialidades</button></a>
                                <a href=""><button id="m" >Contatos</button></a>
                            </div>
                        </div>


                        <nav>
                            <input type="checkbox" id="check" />
                             <label forhtml="check" className="checkbtn" id="check1">
                                <i className="fas fa-bars"></i>
                            </label> 
                            <ul>
                                <div className="menu12" >
                                    <p id="mic1"><a href="#">Consultas</a></p>
                                    <p id="mic"><a href="#">Minha Conta</a></p>
                                    <div className="linha_m"></div>
                                    <p><a href="#" className="vertical-menu">Eu</a></p>
                                </div>
                            </ul>
                        </nav>
                        <section></section>
                    </div>
                </header>


                <div className="dis">

                    <div className="estrutura_lm">

                        <div className="dis1">



                            <img src={perfil} id="ftperfil" alt="Imagem perfil" />
                            {/* <input type="file" id="ftperfil" onblur="carregarFoto(this.value.foto)"></input> */}
                            <div className="colu">
                                <h5 > &nbsp; ADM</h5>
                                <h6>Consultas</h6>
                                <button onClick={apdiv} type="button" id="nova" value= "novaconsulta">+ Nova Consulta</button>
                            </div>

                            <div className="estrutura_nv" id="esnv"  >
                                <img onClick={esdiv} src={x} id="x"  alt="Icone fechar agendamento de consulta"></img>
                                <h2 className="h2nv" >Agendar</h2>
                                <h3 id="h3" >Nova Consulta</h3>

                                <form onSubmit={this.cadastrarConsulta}>
                                    <div className="input-field">

                                        <select onChange={this.atualizaStateCampo} className="select" id="select2" name="nome">

                                            {this.state.listaConsultas.map((consulta) => {
                                                return (
                                                    <option key={consulta.idConsulta}>{consulta.idMedicoNavigation.nome}</option>
                                                )
                                            })
                                            }

                                        </select>

                                    <select
                                            // Instituição
                                            name="idMedico"
                                            // Define que o valor do input é o valor do state
                                            value={this.state.idMedico}
                                            // Chama a função para atualizar o state cada vez que há uma alteração no input
                                            onChange={this.atualizaStateCampo}
                                        >
                                            <option value="0">Medico</option>

                                            {/* Utiliza a função map() para preencher a lista de opções */}

                                            {
                                                // Percorre a lista de Instituições e retorna uma opção para cada instituição
                                                // definindo o valor como seu próprio ID
                                            this.state.listaConsultas.map( consulta=> {
                                                return(
                                                    <option key={consulta.idMedico} value={consulta.idMedico}>
                                                        {consulta.idMedico}
                                                    </option>
                                                );
                                            }   )
                                        }
                                    </select>
                                        
                                    </div>
                                    <div className="input-field">

                                        <select  onChange={this.atualizaStateCampo} className="select" id="select2" name="idPaciente">

                                            {this.state.listaConsultas.map((consulta) => {
                                                return (
                                                    <option value="0" key={consulta.idConsulta}>{consulta.idPacienteNavigation.nome}</option>
                                                )
                                            })
                                            }

                                        </select>
                                    </div>
                                    
                                    <h4 id="h2" >Status</h4>
                                    
                                    <div className="input-field">

                                        <select className="selectnv" id="select" name="situacao">
                                            
                                        {this.state.listaConsultas.map((consulta) => {
                                                return (
                                                    <option key={consulta.idConsulta}>{consulta.situacao}</option>
                                                )
                                            })
                                            }
                                          
                                        </select>
                                    </div>

                                    <div id="dahr">
                                        <h4 id="h4" >Data</h4>
                                        <h4 id="h4" >Hora</h4>
                                    </div>

                                    <div className="select3">
                                        <div id="dahe">
                                            <input
                                                className="select4"
                                                // E-mail
                                                type="date"
                                                name="dataConsulta"
                                                // Define que o input email recebe o valor do state email
                                                value={this.state.dataConsulta}
                                                // Faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                                                onChange={this.atualizaStateCampo}
                                                placeholder="data"
                                            />

                                            <input
                                                className="select4"
                                                name="horaConsulta"
                                                type="time"
                                                value={this.state.horaConsulta}
                                                onChange={this.atualizaStateCampo}
                                            >
                                            </input>

                                        </div>
                                        <h4 id="h4" >Especialidade</h4>

                                        <select name="Especialidade" className="select" id="select2">
                                                
                                        {this.state.listaConsultas.map((consulta) => {
                                                return (
                                                    <option  key={consulta.idMedicoNavigation}>{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</option>
                                                )
                                            })
                                        }
                                        </select>

                                        <button type="submit" id="agend" value="novaconsulta">Agendar</button>
                                    </div>
                                </form>
                            </div>

                        </div>

                        <div>
                            <input id="pes" type="text" placeholder="Nome"></input>
                            <button><div id="lupa"></div></button>
                        </div>

                    <div className="wrap">
                                {
                                    this.state.listaConsultas.map((consulta) => {
                                        return (
                                            
                                            <div className="coln">
                                                <div className="containeradm" >
                                                    <div id="rel">
                                                        <img id="icones" src={calendario} alt="icone calendario" name="dataConsulta" />
                                                        <p id="ps" key={consulta.idConsulta}> {new Date(consulta.dataConsulta).toLocaleDateString()}</p>
                                                    </div>

                                                    <div id="rel">
                                                        <img id="icones" src={relogio} alt="icone relógio" nome="horaConsulta" />
                                                        <p id="ps" key={consulta.idConsulta}>{consulta.horaConsulta}</p>
                                                    </div>

                                                    <div id="rel">
                                                        <img id="icones" src={paciente} alt="icone paciente" name="nome" />
                                                        <p id="pn">{consulta.idPacienteNavigation.nome}</p>
                                                    </div>

                                                    <div id="rel">
                                                        <img id="icones" src={medico} alt="icone médico" name="nome" />
                                                        <p id="pn">{consulta.idMedicoNavigation.nome}</p>
                                                    </div>

                                                    <div id="rel">
                                                        <img id="icones" src={status} alt="icone realizada" nome="situacao" />
                                                        <p id="ps" key={consulta.idConsulta}>{consulta.situacao}</p>
                                                    </div>

                                                     <div id="rel">
                                                        <img id="icones" src={especialidade} alt="icone especialidade" name="nomeEspecialidade" />
                                                         <p id="ps">{consulta.idMedicoNavigation.idEspecialidadeNavigation.nomeEspecialidade}</p> 
                                                    </div> 
                                                </div>

                                            </div>



                                        );
                                    })
                                }
                            </div>
                        </div>   

                    </div>
                </div>
        );
    }
};

function apdiv() {

 document.getElementById("esnv").style.display = "block"

};

function esdiv() {

 document.getElementById("esnv").style.display = "none"

};
export default adm;
