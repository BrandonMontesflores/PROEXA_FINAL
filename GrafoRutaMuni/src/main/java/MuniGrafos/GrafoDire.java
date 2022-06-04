/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package MuniGrafos;

public class GrafoDire {
    
    public char MuniJ(String D) {
        char dire = ':';
        switch (D) {
            case "AguaBlanca":
                dire = 'a';
                break;
            case "AsuncionMita":
                dire = 'b';
                break;
            case "Atescatempa":
                dire = 'c';
                break;
            case "Comapa":
                dire = 'd';
                break;
            case "Conguaco":
                dire = 'e';
                break;
            case "ElAdelanto":
                dire = 'f';
                break;
            case "ElProgreso":
                dire = 'g';
                break;
            case "Jalpatagua":
                dire = 'h';
                break;
            case "Jerez":
                dire = 'i';
                break;
            case "Jutiapa":
                dire = 'j';
                break;
            case "Moyuta":
                dire = 'k';
                break;
            case "Pasaco":
                dire = 'l';
                break;
            case "Quesada":
                dire = 'm';
                break;
            case "SanJoseAcatempa":
                dire = 'n';
                break;
            case "SantaCatarinaMita":
                dire = 'ñ';
                break;
            case "Yupiltepeque":
                dire = 'o';
                break;
            case "Zapotitlan":
                dire = 'p';
                break;
        }
        return dire;
    }    
}
