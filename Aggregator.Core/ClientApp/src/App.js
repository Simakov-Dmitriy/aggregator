import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router-dom'
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Switch>
            <Route exact path='/'><Redirect to = "Home/Index" /></Route>
        </Switch>
    );
  }
}
