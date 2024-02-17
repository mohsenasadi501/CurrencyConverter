import {Card, CardContent, Typography} from '@mui/material'
import './currencyConverter.css';
import DollarInput from "../DollarInput/DollarInput";
import {useEffect, useState} from "react";
import {convertNumberToWords} from "../../api/numberToWords.api"
function CurrencyConverter() {
    const [amount, setAmount] = useState('');
    const [convertedAmount , setConvertedAmount] = useState('');

    const handleAmountChange = async (value:string) => {
        setAmount(value);
    };

    useEffect(() => {
        const fetchConvertedAmount = async () => {
            if (amount) {
                const response = await convertNumberToWords(amount);
                setConvertedAmount(response);
                console.log(amount)
            }
            else
            {
                setConvertedAmount("----")
            }
        };

        fetchConvertedAmount();
    }, [amount]);

    return (
        <>
            <Card className="container" sx={{ boxShadow: 3 }}>
                <img src="../../logo.svg" alt="" width="50px" className="logo"/>
                <div className="content">
                <div className="title">
                    Currency Converter
                </div>
                <div className="individuals">
                    <DollarInput id="amount" value={amount} onChange={handleAmountChange}  />
                </div>
                    <Card className="output" sx={{ boxShadow: 3 }}>
                        <CardContent>
                            <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                {convertedAmount}
                            </Typography>
                        </CardContent>
                    </Card>
                </div>
            </Card>
        </>
        );
}

export default CurrencyConverter;
