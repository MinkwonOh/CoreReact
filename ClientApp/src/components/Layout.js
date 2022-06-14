import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { TitleHeader } from './TitleHeader';
/*
 * /// 튜토리얼 페이지
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
