import React, { Component } from 'react'
import Homepage from './components/Homepage'
import Questions from './components/AllQuestions'
import AllQuestions from './components/Questions'
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom'

class App extends Component {
  render() {
    return (
      <Router>
        <h1 className="header"> Suncoast Overflow </h1>
        <div className="topnav">
          <nav className="nav-bar">
            <Link className="Link-Home" to="/HomePage">
              HomePage
            </Link>
            <Link className="Link-Questions" to="/Questions">
              Questions
            </Link>
            <input type="text" placeholder="Search.." />
            <Link className="Link-All-Questions" to="/AllQuestions">
              All Questions
            </Link>
          </nav>
        </div>

        <Switch>
          <Route exact path="/HomePage" component={Homepage} />
          <Route exact path="/Add" component={Questions} />
          <Route exact path="/:id" component={AllQuestions} />
        </Switch>
      </Router>
    )
  }
}

export default App
