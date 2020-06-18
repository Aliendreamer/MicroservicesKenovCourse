import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import PrivateRoute from "./helpers/privateRoute";
import LoginPage from "./components/PageComponents/LoginPage";
import AccountPage from "./components/PageComponents/AccountPage";
import BasePage from "./components/baseComponents/BasePage";
import RegisterPage from "./components/PageComponents/RegisterPage";

function App() {
	return (
		<BrowserRouter>
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
		</BrowserRouter>
	);
}

export default App;
