import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import PrivateRoute from "./helpers/privateRoute";
import LoginPage from "./components/pageComponents/LoginPage";
import AccountPage from "./components/pageComponents/AccountPage";
import HomePage from "./components/pageComponents/HomePage";
import BasePage from "./components/baseComponents/BasePage";
import RegisterPage from "./components/pageComponents/RegisterPage";
import ErrorBoundary from "./components/baseComponents/ErrorBoundary";

function App() {
	return (
		<BrowserRouter>
			<ErrorBoundary>
				<BasePage>
					<Switch>
						<Route path="/" exact>
							<HomePage />
						</Route>
						<Route path="/login">
							<LoginPage />
						</Route>
						<Route path="/register">
							<RegisterPage />
						</Route>
						<Route path="/logout">
							<RegisterPage />
						</Route>
						<PrivateRoute path="/account" exact component={AccountPage} />
					</Switch>
				</BasePage>
			</ErrorBoundary>
		</BrowserRouter>
	);
}

export default App;
