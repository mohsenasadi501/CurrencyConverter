import { NumericFormat } from "react-number-format";
import "./DollarInput.css";

function DollarInput({ value, onChange }: any) {
    return (
        <NumericFormat
            className="hi"
            value={value}
            decimalScale={2}
            fixedDecimalScale={true}
            allowNegative={false}
            decimalSeparator={','}
            onValueChange={({ floatValue }) => {
                if (floatValue === undefined) {
                    onChange(null);
                } else {
                    onChange(String(floatValue).replace('.', ','));
                }
            }}
            isAllowed={({ floatValue }) => {
                const parts = String(floatValue).split('.');
                const integerPart = parts[0];
                const decimalPart = parts[1] || '';
                return integerPart.length <= 9 && decimalPart.length <= 2;
            }}
        />
    );
}

export default DollarInput;
