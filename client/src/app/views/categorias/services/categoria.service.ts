import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  InserirCategoriaViewModel,
  CategoriaInseridaViewModel,
  CategoriaEditadaViewModel,
  CategoriaExcluidaViewModel,
  VisualizarCategoriaViewModel,
  EdicaoCategoriaViewModel,
  ListarCategoriaViewModel,
} from '../models/categoria.models';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoriaService {
  private readonly url = `${environment.API_URL}/categorias`;

  constructor(private http: HttpClient) {}

  cadastrar(novaCategoria: InserirCategoriaViewModel): Observable<CategoriaInseridaViewModel> {
    return this.http.post<CategoriaInseridaViewModel>(this.url, novaCategoria);
  }

  editar(
    id: string,
    categoriaEditada: EdicaoCategoriaViewModel
  ): Observable<CategoriaEditadaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<CategoriaEditadaViewModel>(urlCompleto, categoriaEditada);
  }

  excluir(id: string): Observable<CategoriaExcluidaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<CategoriaExcluidaViewModel>(urlCompleto);
  }

  selecionarTodos(): Observable<ListarCategoriaViewModel[]> {
    return this.http.get<ListarCategoriaViewModel[]>(this.url);
  }

  selecionarPorId(id: string): Observable<VisualizarCategoriaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarCategoriaViewModel>(urlCompleto);
  }
}
