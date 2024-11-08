import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  CadastroCategoria,
  CategoriaCriada,
  CategoriaEditada,
  CategoriaExcluida,
  DetalhesCategoria,
  EdicaoCategoria,
  ListagemCategoria,
} from '../models/categoria.models';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoriaService {
  private readonly url = `${environment.API_URL}/categorias`;

  constructor(private http: HttpClient) {}

  cadastrar(novaCategoria: CadastroCategoria): Observable<CategoriaCriada> {
    return this.http.post<CategoriaCriada>(this.url, novaCategoria);
  }

  editar(
    id: number,
    categoriaEditada: EdicaoCategoria
  ): Observable<CategoriaEditada> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<CategoriaEditada>(urlCompleto, categoriaEditada);
  }

  excluir(id: number): Observable<CategoriaExcluida> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<CategoriaExcluida>(urlCompleto);
  }

  selecionarTodos(): Observable<ListagemCategoria[]> {
    return this.http.get<ListagemCategoria[]>(this.url);
  }

  selecionarPorId(id: number): Observable<DetalhesCategoria> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<DetalhesCategoria>(urlCompleto);
  }
}
