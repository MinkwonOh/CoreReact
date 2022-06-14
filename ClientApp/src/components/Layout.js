import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { TitleHeader } from './TitleHeader';
/*
 * /// Ʃ�丮�� ������
 * import { NavMenu } from './NavMenu';
 * */


export class Layout extends Component {
    static displayName = Layout.name;
  
    render () {
        return (
        <div>
            {/*<NavMenu />*/}
            <TitleHeader/>
            <Container>
                {this.props.children}
            </Container>
            </div>
        );
    }
}
