import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import PrivateRoute from "./helpers/privateRoute";
import LoginPage from "./components/pageComponents/LoginPage";
import AccountPage from "./components/pageComponents/AccountPage";
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
							<AccountPage />
						</Route>
						<Route path="/login">
							<LoginPage />
						</Route>
						<Route path="/register">
							<RegisterPage />
						</Route>
						<PrivateRoute path="/protected" component={null} />
					</Switch>
				</BasePage>
			</ErrorBoundary>
		</BrowserRouter>
	);
}

export default App;
