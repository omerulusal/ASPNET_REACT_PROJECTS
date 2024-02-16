import React, { createContext, useState } from "react";

interface IThemeContext {
    darkMode: boolean;
    toggleTheme: () => void;
}

export const ThemeContext = createContext<IThemeContext>({
    darkMode: false,
    toggleTheme: () => { },
})


interface IThemeContextProviderProps {
    children: React.ReactNode
}


export const ThemeContextProvider: React.FC<IThemeContextProviderProps> = ({ children }) => {

    const [darkM, setDarkM] = useState<boolean>(false)
    const toggleTheme = () => {
        setDarkM((ilkHal) => !ilkHal)
    }

    return <ThemeContext.Provider value={{ darkMode: darkM, toggleTheme }}>{children}</ThemeContext.Provider>;

}

export default ThemeContextProvider;