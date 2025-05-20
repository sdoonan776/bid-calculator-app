/// <reference types="vite/client" /> 
declare module '*.vue' { 
    import { DefineComponent } from 'vue'; 
    const comp: DefineComponent<{}, {}, any>; 
    export default comp; 
}