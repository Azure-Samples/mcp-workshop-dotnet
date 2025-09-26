/// <summary>
/// 원숭이의 기본 정보를 나타내는 모델 클래스입니다.
/// </summary>
public class Monkey
{
    /// <summary>
    /// 원숭이 이름
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 서식지(지역)
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// 개체수
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// ASCII 아트(시각적 표현)
    /// </summary>
    public string AsciiArt { get; set; }
}
