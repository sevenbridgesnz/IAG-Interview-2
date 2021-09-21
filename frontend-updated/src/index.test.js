import App from "./App";
import { render, screen } from "@testing-library/react";
import { configure, shallow } from "enzyme";
import Adapter from 'enzyme-adapter-react-17-updated';
import { Provider } from "react-redux";
import store from './store/index';


describe('Main App', () => {
    configure({adapter: new Adapter()});

    test('Renders App without crashing', () => {
        shallow(<App />);
    });       

    test('Renders whole app without crashing', () => {        
        render(<Provider store = {store}> <App /></Provider>);      
    });       

});