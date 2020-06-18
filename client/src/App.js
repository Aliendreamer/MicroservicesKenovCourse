import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import PrivateRoute from "./helpers/privateRoute";
import LoginPage from "./components/PageComponents/LoginPage";
import AccountPage from "./components/PageComponents/AccountPage";
import BasePage from "./components/baseComponents/basePage";

function App() {
	return (
		<BasePage>
			<BrowserRouter>
				<Switch>
					<Route path="/" exact>
						<AccountPage />
					</Route>
					<Route path="/login">
						<LoginPage />
					</Route>
					<PrivateRoute path="/protected" component={null} />
				</Switch>
			</BrowserRouter>
		</BasePage>
	);
}

export default App;
