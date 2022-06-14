import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './TitleHeader.css';

export class TitleHeader extends Component {
  static displayName = TitleHeader.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    }
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar expand="md" className="navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" color="dark" dark light>
          <Container>
            <NavbarBrand tag={Link} to="/">OhRockSeal</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} />
            <Collapse className="d-md-inline-flex flex-md-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-black" to="/">Main</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}