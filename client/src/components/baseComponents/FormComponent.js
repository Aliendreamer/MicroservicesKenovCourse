/* eslint-disable react/jsx-closing-tag-location */
import React from "react";
import { useForm, Controller, ErrorMessage } from "react-hook-form";
import { authInstanceActions } from "../../helpers/axiosFactory";
import { Form, FormGroup, Label, Input, Button, Jumbotron, Container } from "reactstrap";
import { useHistory } from "react-router-dom";

const FormComponent = ({ isLogin }) => {
	const { errors, control, handleSubmit } = useForm();
	const history = useHistory();
	const onSubmit = data => {
		authInstanceActions("POST", "users/register", data);
	};

	return (
		<Jumbotron fluid>
			<Container fluid>
				<Form onSubmit={handleSubmit(onSubmit)}>
					<FormGroup>
						<Label for="FirstName">FirstName</Label>
						<Controller
							as={Input}
							name="FirstName" placeholder="FirstName"
							id="FirstName"
							control={control}
							rules={{ required: "This is required" }}
						/>
						<ErrorMessage errors={errors} name="FirstName" as="p" />
					</FormGroup>
					{!isLogin
						? <>
							<FormGroup>
								<Label for="LastName">LastName</Label>
								<Controller
									as={Input}
									name="LastName"
									placeholder="LastName"
									id="LastName"
									control={control}
									rules={{ required: "This is required" }}
								/>
								<ErrorMessage errors={errors} name="LastName" as="p" />
							</FormGroup>
							<FormGroup>
								<Label for="UserName">LastName</Label>
								<Controller
									as={Input}
									name="UserName"
									placeholder="UserName"
									id="LastName"
									control={control}
									rules={{ required: "This is required" }}
								/>
								<ErrorMessage errors={errors} name="UserName" as="p" />
							</FormGroup>
						</>
						: null}
					<FormGroup>
						<Label for="Password">Password</Label>
						<Controller
							as={Input}
							name="Password"
							placeholder="Password"
							id="Password"
							control={control}
							rules={{ required: "This is required" }}
						/>
						<ErrorMessage errors={errors} name="UserName" as="p" />
					</FormGroup>
					<Button type="submit">{isLogin ? "Login" : "Register"}</Button>
				</Form>
				{!isLogin && <Button color="link" onClick={() => history.push("/login")}>Already have account?</Button>}
			</Container>
		</Jumbotron>
	);
};
export default FormComponent;
