export class Utils {
  static nomeConcat(item: any[]) {
    return item.map(x => x.disciplina.titulo).join(',');
  }
}
