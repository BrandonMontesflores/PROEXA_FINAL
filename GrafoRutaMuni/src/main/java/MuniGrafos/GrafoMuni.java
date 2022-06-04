/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MuniGrafos;

public class GrafoMuni {
    
    public String munij(char di) {
        String municipio = "";
        switch (di) {
            case 'a':
                municipio = "AguaBlanca";
                break;
            case 'b':
                municipio = "AsuncionMita";
                break;
            case 'c':
                municipio = "Atescatempa";
                break;
            case 'd':
                municipio = "Comapa";
                break;
            case 'e':
                municipio = "Conguaco";
                break;
            case 'f':
                municipio = "ElAdelanto";
                break;
            case 'g':
                municipio = "ElProgreso";
                break;
            case 'h':
                municipio = "Jalpatagua";
                break;
            case 'i':
                municipio = "Jerez";
                break;
            case 'j':
                municipio = "Jutiapa";
                break;
            case 'k':
                municipio = "Moyuta";
                break;
            case 'l':
                municipio = "Pasaco";
                break;
            case 'm':
                municipio = "Quesada";
                break;
            case 'n':
                municipio = "SanJoseAcatempa";
                break;
            case 'ñ':
                municipio = "SantaCatarinaMita";
                break;
            case 'o':
                municipio = "Yupiltepeque";
                break;
            case 'p':
                municipio = "Zapotitlan";
                break;
        }
        return municipio;
    }
}
