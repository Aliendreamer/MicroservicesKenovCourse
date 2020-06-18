/* eslint-disable react/jsx-closing-tag-location */
import React from "react";
import { useForm } from "react-hook-form";
import { authInstanceActions } from "../../helpers/axiosFactory";

const Form = ({ isLogin }) => {
	const { register, handleSubmit, errors } = useForm();
	const onSubmit = data => {
		debugger;
		authInstanceActions("POST", "users/register", data);
	};

	return (
		<form onSubmit={handleSubmit(onSubmit)}>
			<input name="FirstName" defaultValue="FirstName" ref={register({ required: true })} />
			{errors.FirstName && <span>This field is required</span>}
			{!isLogin
				? <>
					<input name="LastName" defaultValue="FirstName" ref={register({ required: true })} />
					{errors.LastName && <span>This field is required</span>}

					<input name="UserName" defaultValue="FirstName" ref={register({ required: true })} />
					{errors.UserName && <span>This field is required</span>}
				</>
				: null}

			<input name="Password" type="password" defaultValue="password" ref={register({ required: true })} />
			{errors.Password && <span>This field is required</span>}
			<input type="submit" />
		</form>
	);
};
export default Form;
