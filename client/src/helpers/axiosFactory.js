import axios from "axios";
const authInstance = axios.create({
	baseURL: process.env.REACT_APP_BASE_AUTH_URL,
	responseType: "json",
	timeout: 5000
});
const apiInstance = axios.create({
	baseURL: process.env.REACT_APP_BASE_URL,
	responseType: "json",
	timeout: 5000
});
export const authInstanceActions = async (method, url, data) => {
	try {
		let response;
		switch (method) {
			case "GET":
				response = await authInstance.get(url, data);
				break;
			case "POST":
				debugger;
				response = await authInstance.post(url, data);
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		console.log(error);
		debugger;
		return { data: null, error: "RequestError" };
	}
};

export const useApiInstance = async (method, url, data) => {
	try {
		let response;
		switch (method) {
			case "GET":
				response = await apiInstance.get(url, data);
				break;
			case "Post":
				response = await apiInstance.get(url, data);
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		return { data: null, error: "RequestError" };
	}
};
