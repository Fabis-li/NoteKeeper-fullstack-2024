import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditarNotaViewModel, InserirNotaViewModel, ListarNotaViewModel, NotaEditadaViewModel, NotaExcluidaViewModel, NotaInseridaViewModel, VisualizarNotaViewModel } from '../models/nota.models';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NotaService {

  private readonly url = `${environment.API_URL}/notas`;

  constructor(private http: HttpClient) {}

  cadastrar(novaNota: InserirNotaViewModel): Observable<NotaInseridaViewModel> {
    return this.http.post<NotaInseridaViewModel>(this.url, novaNota);
  }

  editar(id: string, notaEditada: EditarNotaViewModel): Observable<NotaEditadaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<NotaEditadaViewModel>(urlCompleto, notaEditada);
  }

  excluir(id: string): Observable<NotaExcluidaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<NotaExcluidaViewModel>(urlCompleto);
  }

  selecionarTodos(): Observable<ListarNotaViewModel[]> {
    const urlCompleto = `${this.url}?arquivadas=false`;

    return this.http.get<ListarNotaViewModel[]>(urlCompleto);
  }

  selecionarArquivadas(): Observable<ListarNotaViewModel[]> {
    const urlCompleto = `${this.url}?arquivadas=true`;

    return this.http.get<ListarNotaViewModel[]>(urlCompleto);
  }

  selecionarPorId(id: string): Observable<VisualizarNotaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarNotaViewModel>(urlCompleto);
  }

  alterarStatus(id: string): Observable<VisualizarNotaViewModel> {
    const urlCompleto = `${this.url}/${id}/alterar-status`;

    return this.http.put<VisualizarNotaViewModel>(urlCompleto,{});
  }
}
