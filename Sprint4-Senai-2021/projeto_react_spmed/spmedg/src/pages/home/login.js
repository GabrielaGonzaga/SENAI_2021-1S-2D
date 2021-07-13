
import { React, Component } from 'react';
import axios from 'axios';

import '../../assets/css/style.css';

import { parseJwt, usuarioAutenticado } from '../../services/auth';

//IMAGENS
import logo from '../../assets/img/logologin.png';

class login extends Component{
  constructor(props){
      super(props);
      this.state = {
          listaConsultas : [],
          nomeUsuario:'',
          email : '',
          senha : ''
      }
    }

    efetuaLogin = (event) =>{

      event.preventDefault();

      this.setState({ erroMensagem : '', isLoading : true });

      axios.post('http://localhost:5000/api/Logins', {

      nomeUsuario: this.state.senha,
      email: this.state.email,
      senha: this.state.senha
      
    })

    .then(resposta => {
      // Caso o status code seja 200,
      if (resposta.status === 200) {
          // salva o token no localStorage,
          localStorage.setItem('usuario-login', resposta.data.token);
          // exibe o token no console do navegador
          console.log('Meu token é: ' + resposta.data.token);
          // e define que a requisição terminou
          this.setState({ isLoading : false })

          // Define a variável base64 que vai receber o payload do token
          let base64 = localStorage.getItem('usuario-login').split('.')[1];
          // Exibe no console o valor presente na variável base64
          console.log(base64);
          // Exibe no console o valor convertido de base64 para string
          console.log(window.atob(base64));
          // Exibe no console o valor convertido da string para JSON
          console.log(JSON.parse(window.atob(base64)));

          // Exibe no console apenas o tipo de usuário logado
          console.log(parseJwt().role);

          // Verifica se o tipo de usuário logado é Administrador
          // Se for, redireciona para a página de Tipos Eventos
          if (parseJwt().role === '1') {
              console.log('tipos user ' + parseJwt().role)
              console.log(this.props);

              return this.props.history.push('/adm');
              console.log('estou logado: ' + usuarioAutenticado());
          }

          if (parseJwt().role === '2') {
              console.log('tipos user ' + parseJwt().role)
              console.log(this.props);

              return this.props.history.push('/medicos');
              console.log('estou logado: ' + usuarioAutenticado());
          }

          if (parseJwt().role === '3') {
              console.log('tipos user ' + parseJwt().role)
              console.log(this.props);

              return this.props.history.push('/pacientes');
              console.log('estou logado: ' + usuarioAutenticado());
          }

          // Se não for, redireciona para a página home
          else {
              this.props.history.push('/')
          }
      }
  })

  // Caso haja um erro,
  .catch(() => {
      // define o state erroMensagem com uma mensagem personalizada e que a requisição terminou
      this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false });
  })
}

// Função genérica que atualiza o state de acordo com o input
// pode ser reutilizada em vários inputs diferentes
atualizaStateCampo = (campo) => {
  this.setState({ [campo.target.name] : campo.target.value })
};

render(){
  return(
  <div className="body">
      <div id="fundo_f" ></div> 
          <main className="estrutura" >
            <div>
              <div className="estd">
                <a><img id="logol" src={logo} alt=""/></a>
              </div>
              <h2 >Login</h2>

                <form onSubmit={this.efetuaLogin}>

                  <div className="input-field"  >
                  <input
                    id="login__email"
                    className="input__login"
                    // E-mail
                    type="text"
                    name="email"
                    // Define que o input email recebe o valor do state email
                    value={this.state.email}
                    // Faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                    onChange={this.atualizaStateCampo}
                    placeholder="email"
                    />
                      <div className="linha"></div>
                    </div>
                    <div className="input-field"  >
                    <input 
                      id="login__password"
                      className="input__login"
                      // Senha
                      type="password"
                      name="senha"
                      // Define que o input senha recebe o valor do state senha
                      value={this.state.senha}
                      // Faz a chamada para a função que atualiza o state, conforme
                      // o usuário altera o valor do input
                      onChange={this.atualizaStateCampo}
                      placeholder="senha"
                                        />
                      <div className="linha"></div>

                      {/* Exibe a mensagem de erro ao tentar logar com credenciais inválidas */}
                      <p style={{ color : 'red', textAlign : 'center', fontSize: '0.8rem' }}>{this.state.erroMensagem}</p>
                   
                         {/* 
                                        Verifica se a requisição está em andamento
                                        Se estiver, desabilita o click do botão
                        */}

                        
                        {
                        // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                        this.state.isLoading === true &&
                            
                          <p style={{ color : 'red', textAlign : 'center', fontSize: '0.9rem' }} type="submit" disabled>Carregando...</p>
                            
                        }

                        {
                        // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                        this.state.isLoading === false &&
                            <p
                                style={{ color : 'red', textAlign : 'center', fontSize: '0.9rem' }}
                                disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
                                
                            </p>
                        }              

                    <div  className="spa"></div>
                      <input type="submit" value="Entrar"/>

                    <div className="ou" ><p>ou</p></div>

                    <input type="button" value="Cadastre-se" />

                    {/* <a href="http://127.0.0.1:5502/Cadastro.html"><input type="submit" value="Cadastre-se" ></a> */}

                  </div>
                </form>
            </div>
      </main>
  </div>
    );
  }
}
export default login;
