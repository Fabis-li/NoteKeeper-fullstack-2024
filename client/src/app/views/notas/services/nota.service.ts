import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CadastroNota,
  DetalhesNota,
  EdicaoNota,
  ListagemNota,
  NotaCriada,
  NotaEditada,
  NotaExcluida,
} from '../models/nota.models';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NotaService {
  private readonly url = `${environment.API_URL}/notas`;

  constructor(private http: HttpClient) {}

  cadastrar(novaNota: CadastroNota): Observable<NotaCriada> {
    return this.http.post<NotaCriada>(this.url, novaNota);
  }

  editar(id: number, notaEditada: EdicaoNota): Observable<NotaEditada> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<NotaEditada>(urlCompleto, notaEditada);
  }

  excluir(id: number): Observable<NotaExcluida> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<NotaExcluida>(urlCompleto);
  }

  selecionarTodos(): Observable<ListagemNota[]> {
    const urlCompleto = `${this.url}?arquivada=false&_expand=categoria`;

    return this.http.get<ListagemNota[]>(urlCompleto);
  }

  selecionarArquivadas(): Observable<ListagemNota[]> {
    const urlCompleto = `${this.url}?arquivada=true&_expand=categoria`;

    return this.http.get<ListagemNota[]>(urlCompleto);
  }

  selecionarPorId(id: number): Observable<DetalhesNota> {
    const urlCompleto = `${this.url}/${id}?_expand=categoria`;

    return this.http.get<DetalhesNota>(urlCompleto);
  }
}
