export default async function useCalculateFees(price: number, type: string) 
{
    try {
        const baseUrlPath = "http://localhost:5079/" 
        const response = await fetch(`${baseUrlPath}api/v1/bidcalculator/calculate?price=${price}&type=${type}`);
        return response.json();
    } catch (error) {
        return error;
    }
}