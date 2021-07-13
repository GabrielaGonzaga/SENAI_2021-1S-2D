import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';
import Login from './pages/home/login';
import Medicos from './pages/medicos/medicos';
import Adm from './pages/adm/adm'
import Pacientes from './pages/pacientes/pacientes';
import NotFound from './pages/notFound/notfound';

import reportWebVitals from './reportWebVitals';


const PermissaoAdm = ({ component : Component  }) => (
  <Route 
    render = { props =>
      // Verifica se o usuário está logado e se é Administrador
      usuarioAutenticado() && parseJwt().role === "1" ? 
      // Se sim, renderiza de acordo com a rota solicitada e permitida
      <Component {...props} /> : 
      // Se não, redireciona para a página de login
      <Redirect to = '/adm' />
    }
  />
);


const PermissaoMedico= ({ component : Component }) => (
  <Route
    render = { props =>
      // Verifica se o usuário está logado e se é Comum
      usuarioAutenticado() && parseJwt().role === "2" ?
      // Se sim, renderiza de acordo com a rota solicitada e permitida
      <Component {...props} /> :
      // Se não, redireciona para a página de login
      <Redirect to = '/medicos' />
    }
  />
);

const PermissaoComum = ({ component : Component }) => (
  <Route
    render = { props =>
      // Verifica se o usuário está logado e se é Comum
      usuarioAutenticado() && parseJwt().role === "3" ?
      // Se sim, renderiza de acordo com a rota solicitada e permitida
      <Component {...props} /> :
      // Se não, redireciona para a página de login
      <Redirect to = '/pacientes' />
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} /> {/* Home */}
        <PermissaoMedico path="/medicos" component={Medicos} /> {/*Medicos*/}
        <PermissaoAdm path="/adm" component={Adm} /> {/*Adm*/}
        <PermissaoComum path="/pacientes" component={Pacientes} /> {/*Pacientes*/}
        <Route exact path="/notfound" component={NotFound} /> {/* Not Found */}
        <Redirect to = "/notfound"/> {/* Redireciona para NotFound caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring hg performance in your app, pass a function
// to log results (foore example: reportWebVitals(console.log))
// or sendftrod to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
