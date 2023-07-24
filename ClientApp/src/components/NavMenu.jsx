import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { useLogin } from '../hooks/Login';

export function NavMenu()  {
  const { user } = useLogin()


    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to={!user ? "/" : '/tela-evento'}>SistemaOlimpo</NavbarBrand>
          <div>
            <ul className="navbar-nav flex-grow gap-2">
              <Collapse isOpen={!user} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Login</NavLink>
                </NavItem>
              </Collapse>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/tela-equipe">Cadastrar Equipe</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/tela-equipes">Equipes</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/tela-evento">Tela Evento</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/tela-cadastro-evento">Cadastrar evento</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/tela-TDP">Enviar TDP</NavLink>
              </NavItem>
            </ul>
          </div>
        </Navbar>
      </header>
    );

}