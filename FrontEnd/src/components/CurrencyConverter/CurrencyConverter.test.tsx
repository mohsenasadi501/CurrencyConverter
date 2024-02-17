import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import CurrencyConverter from './CurrencyConverter';

describe('CurrencyConverter component', () => {
    test('renders without crashing', () => {
        render(<CurrencyConverter />);
    });

    test('updates amount input correctly', () => {
        render(<CurrencyConverter />);
        const amountInput = screen.getByRole('textbox') as HTMLInputElement;

        fireEvent.change(amountInput, { target: { value: '100' } });

        expect(amountInput.value).toBe('100,00');
    });
});
