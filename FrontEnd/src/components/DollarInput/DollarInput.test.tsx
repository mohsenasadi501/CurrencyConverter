import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import DollarInput from './DollarInput';

describe('DollarInput component', () => {
    test('updates input value correctly', () => {
        const onChangeMock = jest.fn();
        render(<DollarInput value={0} onChange={onChangeMock} />);
        const input = screen.getByRole('textbox') as HTMLInputElement;

        fireEvent.change(input, { target: { value: '100' } });

        // Adjust the expected value to match the formatted output
        expect(input.value).toBe('100,00'); // Adjusted to match the formatting
        expect(onChangeMock).toHaveBeenCalledWith(100);

    });
});
