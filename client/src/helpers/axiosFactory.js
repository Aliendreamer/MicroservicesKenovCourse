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
	debugger;
	try {
		let response;
		switch (method) {
			case "GET":
				response = await authInstance.get(url, data);
				break;
			case "POST":
				response = await authInstance.post(url, data);
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		return { data: null, error: "RequestError" };
	}
};

export const useApiInstance = async (method, url, data) => {
	try {
		let response;
		switch (method) {
			case "GET":
				response = await apiInstance.get(url, data).catch(err => { throw Error(err.Message); });
				break;
			case "Post":
				response = await apiInstance.get(url, data).catch(err => { throw Error(err.Message); });
				break;
			default:
				break;
		}
		return { data: response.data, error: null };
	} catch (error) {
		return { data: null, error: "RequestError" };
	}
};
