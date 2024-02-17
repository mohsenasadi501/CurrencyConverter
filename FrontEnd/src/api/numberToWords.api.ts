import {baseAPI} from "./base.api";

const url = "/api/Currency?"
export const convertNumberToWords = async (number:string) => {
    try {
        const response  = await baseAPI.get(url,{
            params : {
                number: number,
            },
            headers: {
                'accept': '*/*'
            }
        });
        return response.data;
        console.log(number)
    } catch (error) {
        console.error('Failed to convert number to words:', error);
        throw error;
    }
}
